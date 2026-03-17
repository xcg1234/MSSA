import { useEffect, useState } from 'react';

async function apiFetch(path, options) {
  const response = await fetch(path, options);
  if (!response.ok) {
    const body = await response.json().catch(() => ({}));
    throw new Error(body.error || `Request failed: ${response.status}`);
  }

  if (response.status === 204) {
    return null;
  }

  return response.json();
}

function formatDate(value) {
  if (!value) return '-';
  const date = new Date(value);
  if (Number.isNaN(date.getTime())) return value;
  return date.toLocaleString();
}

export default function App() {
  const [authorized, setAuthorized] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const [activities, setActivities] = useState([]);
  const [yearly, setYearly] = useState({});
  const [records, setRecords] = useState({});
  const [lastUpdated, setLastUpdated] = useState('');

  const refreshStatus = async () => {
    const data = await apiFetch('/api/strava/auth/status');
    setAuthorized(Boolean(data?.authorized));
    return Boolean(data?.authorized);
  };

  const loadDashboard = async () => {
    setLoading(true);
    setError('');

    try {
      const isAuthorized = await refreshStatus();
      if (!isAuthorized) {
        setActivities([]);
        setYearly({});
        setRecords({});
        return;
      }

      const [activitiesData, yearlyData, recordsData] = await Promise.all([
        apiFetch('/api/strava/activities?count=10'),
        apiFetch('/api/strava/yearly-comparison'),
        apiFetch('/api/strava/personal-records')
      ]);

      setActivities(activitiesData || []);
      setYearly(yearlyData || {});
      setRecords(recordsData || {});
      setLastUpdated(new Date().toLocaleTimeString());
    } catch (err) {
      setError(err.message || 'Unknown error.');
    } finally {
      setLoading(false);
    }
  };

  const connectStrava = async () => {
    setError('');

    try {
      const data = await apiFetch('/api/strava/auth/url');
      if (!data?.url) {
        throw new Error('Authorization URL not found.');
      }

      window.open(data.url, '_blank', 'noopener,noreferrer');
    } catch (err) {
      setError(err.message || 'Failed to get authorization URL.');
    }
  };

  const logout = async () => {
    setError('');

    try {
      await apiFetch('/api/strava/auth/logout', { method: 'POST' });
      setAuthorized(false);
      setActivities([]);
      setYearly({});
      setRecords({});
      setLastUpdated('');
    } catch (err) {
      setError(err.message || 'Failed to logout.');
    }
  };

  useEffect(() => {
    loadDashboard();
  }, []);

  return (
    <main className="page">
      <header className="header card">
        <div>
          <h1>Strava Dashboard</h1>
          <p>Recent activities, yearly stats and personal records.</p>
          {lastUpdated && <small>Last updated: {lastUpdated}</small>}
        </div>
        <div className="actions">
          <button onClick={connectStrava}>Connect Strava</button>
          <button onClick={loadDashboard} disabled={loading}>
            {loading ? 'Refreshing...' : 'Refresh'}
          </button>
          <button className="danger" onClick={logout}>Disconnect</button>
        </div>
      </header>

      <section className="card">
        <h2>Authorization</h2>
        <p>Status: <strong>{authorized ? 'Connected' : 'Not connected'}</strong></p>
        <p className="muted">
          After authorization in the popup, click <strong>Refresh</strong>.
        </p>
      </section>

      {error && <section className="card error">{error}</section>}

      <section className="grid">
        <article className="card">
          <h2>Yearly Comparison</h2>
          {Object.keys(yearly).length === 0 ? (
            <p className="muted">No yearly data.</p>
          ) : (
            <div className="stack">
              {Object.entries(yearly)
                .sort(([a], [b]) => Number(b) - Number(a))
                .map(([year, stats]) => (
                  <div key={year} className="subcard">
                    <h3>{year}</h3>
                    <p>Run: {stats.runMiles?.toFixed?.(2) ?? 0} mi ({stats.runCount ?? 0})</p>
                    <p>Ride: {stats.bikeMiles?.toFixed?.(2) ?? 0} mi ({stats.bikeCount ?? 0})</p>
                  </div>
                ))}
            </div>
          )}
        </article>

        <article className="card">
          <h2>Personal Records</h2>
          <div className="stack">
            {[
              ['Longest Run', records.longestRun],
              ['Fastest Run Pace', records.fastestRunPace],
              ['Longest Ride', records.longestRide],
              ['Fastest Ride', records.fastestRide],
              ['Most Elevation Gain', records.mostElevationGain]
            ].map(([label, value]) => (
              <div key={label} className="subcard">
                <h3>{label}</h3>
                {value ? (
                  <>
                    <p>{value.name}</p>
                    <p>{value.value} ¡¤ {value.duration}</p>
                    <small>{formatDate(value.date)}</small>
                  </>
                ) : (
                  <p className="muted">No record yet.</p>
                )}
              </div>
            ))}
          </div>
        </article>
      </section>

      <section className="card">
        <h2>Recent Activities</h2>
        {activities.length === 0 ? (
          <p className="muted">No activities found.</p>
        ) : (
          <ul className="activity-list">
            {activities.map((activity) => (
              <li key={activity.id}>
                <strong>{activity.name}</strong>
                <span>{activity.type}</span>
                <span>{activity.distanceInMiles}</span>
                <span>{activity.duration}</span>
                <span>{formatDate(activity.start_date_local)}</span>
              </li>
            ))}
          </ul>
        )}
      </section>
    </main>
  );
}
