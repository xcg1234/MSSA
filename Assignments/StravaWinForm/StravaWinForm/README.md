# Strava WinForms Application - Design Document

## Overview
A Windows Forms application built on .NET 10 that integrates with the Strava API to provide athletes with comprehensive activity tracking, yearly comparisons, and personal records analysis. The application uses OAuth 2.0 for secure authentication and provides a rich user interface for visualizing fitness data.

---

## Architecture

### High-Level Design
The application follows a **three-tier architecture**:
1. **Presentation Layer** (UI) - Windows Forms (`Form1.cs`)
2. **Service Layer** - Business logic and API integration (`StravaAuthService`, `StravaApiService`)
3. **Data Layer** - Models representing Strava data (`StravaActivity`, `PersonalRecords`, etc.)

### Technology Stack
- **Framework**: .NET 10 (Windows)
- **UI**: Windows Forms
- **Authentication**: OAuth 2.0 with PKCE
- **Security**: DPAPI (Data Protection API) for token encryption
- **API Communication**: HttpClient with REST
- **Data Format**: JSON serialization/deserialization

---

## Key Services

### 1. StravaAuthService
**Purpose**: Manages OAuth 2.0 authentication flow and secure token management for Strava API access.

**Key Responsibilities**:
- **OAuth Flow Management**: Initiates browser-based authorization and captures callback codes via local HTTP listener
- **Token Exchange**: Converts authorization codes to access/refresh tokens
- **Token Refresh**: Automatically refreshes expired access tokens (checks 5 minutes before expiration)
- **Secure Storage**: Encrypts and stores tokens using Windows DPAPI (Data Protection API) with CurrentUser scope
- **Token Validation**: Provides valid access tokens by checking expiration and auto-refreshing when needed

**Security Features**:
- Tokens stored in encrypted `.dat` file (not plain JSON)
- Uses `ProtectedData.Protect()` with user-level encryption
- Only the current Windows user can decrypt stored tokens
- Automatic token rotation to minimize exposure window

**Key Methods**:
- `GetAuthorizationCodeAsync()` - Opens browser for user authorization
- `ExchangeCodeForTokensAsync()` - Exchanges code for tokens
- `RefreshAccessTokenAsync()` - Refreshes expired tokens
- `GetValidAccessTokenAsync()` - Returns current valid token (auto-refreshes if needed)

---

### 2. StravaApiService
**Purpose**: Handles all Strava API interactions and data retrieval operations.

**Key Responsibilities**:
- **Activity Retrieval**: Fetches recent activities with configurable count
- **Yearly Comparison**: Aggregates activity data by year for running and biking statistics
- **Personal Records**: Analyzes all activities to find performance peaks
- **Pagination**: Handles large datasets by iterating through paginated API responses

**Data Operations**:
- **Recent Activities**: Limited fetch (default 5 activities) for quick dashboard view
- **Yearly Stats**: Filtered fetch by date range with aggregation by activity type
- **PR Analysis**: Complete activity history fetch with LINQ-based filtering and sorting

**Key Methods**:
- `GetActivitiesAsync(count)` - Retrieves most recent N activities
- `GetYearlyComparisonAsync()` - Compares current year vs. previous year statistics
- `GetPersonalRecordsAsync()` - Calculates all-time personal bests across categories
- `FetchAllActivities()` - Private helper for paginated full-history retrieval
- `FetchYearActivities()` - Private helper for year-specific data aggregation

**Performance Considerations**:
- Uses pagination (200 items per page) for efficient API usage
- Reuses HttpClient instances with proper disposal
- Implements bearer token authentication per request

---

### 3. Form1 (UI Controller)
**Purpose**: Main application window that orchestrates user interactions and data display.

**Key Responsibilities**:
- **Service Initialization**: Loads configuration from `appsettings.json` and instantiates services
- **Connection Management**: Handles Strava authorization workflow with user feedback
- **Data Display**: Presents activities in DataGridView with formatted columns
- **Dashboard Updates**: Shows yearly running/biking comparisons
- **Personal Records**: Displays lifetime bests across multiple categories

**UI Features**:
- Connection status indicator
- Progress bar for async operations
- DataGridView for tabular activity data
- Yearly comparison labels (current vs. previous year)
- Personal record displays with details

**Key Methods**:
- `InitializeServices()` - Loads app settings and creates service instances
- `btnConnect_Click()` - Initiates OAuth flow
- `LoadActivitiesAsync()` - Displays recent activities
- `LoadYearlyComparisonAsync()` - Updates dashboard statistics
- `LoadPersonalRecordsAsync()` - Shows all-time personal bests

**User Experience**:
- Async/await pattern for non-blocking UI
- Error handling with MessageBox feedback
- Visual progress indicators during operations
- Auto-load activities on successful connection

---

## Data Models

### StravaActivity
Represents a single Strava activity (run, ride, etc.).

**Properties**:
- Core: `id`, `name`, `type`, `distance`, `moving_time`
- Dates: `start_date`, `start_date_local`
- Performance: `average_speed`, `average_heartrate`, `total_elevation_gain`
- Computed: `DistanceInMiles`, `PacePerMile`, `Duration`

### PersonalRecords
Container for athlete's all-time best performances.

**Categories**:
- `LongestRun` - Greatest distance run
- `FastestRunPace` - Best pace per mile
- `LongestRide` - Greatest distance biked
- `FastestRide` - Highest average speed
- `MostElevationGain` - Maximum climbing in single activity

### YearlyStats
Aggregated statistics for a calendar year.

**Metrics**:
- `RunMiles`, `RunCount` - Running totals
- `BikeMiles`, `BikeCount` - Cycling totals

### AppSettings
Configuration model loaded from `appsettings.json`.

**Structure**:
```json
{
  "Strava": {
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret",
    "RedirectUri": "http://localhost:8080/"
  }
}
```

---

## Application Flow

### Startup Flow
1. `Program.Main()` initializes Windows Forms application
2. `Form1` constructor calls `InitializeServices()`
3. Configuration loaded from `appsettings.json`
4. `StravaAuthService` and `StravaApiService` instantiated
5. `Form1_Load` checks for existing authorization
6. If authorized, auto-loads recent activities

### Authentication Flow
1. User clicks "Connect to Strava" button
2. `StravaAuthService.GetAuthorizationCodeAsync()` opens browser
3. Local HTTP listener on `localhost:8080` awaits callback
4. User authorizes on Strava's website
5. Authorization code captured from redirect URL
6. `ExchangeCodeForTokensAsync()` swaps code for tokens
7. Tokens encrypted and saved to `strava_tokens.dat`
8. Activities automatically loaded

### Data Retrieval Flow
1. User requests data (activities, stats, or PRs)
2. `StravaApiService` calls `GetValidAccessTokenAsync()`
3. Token validated; refreshed if expired
4. HTTP request made with Bearer token
5. JSON response deserialized to model objects
6. Data displayed in UI components

---

## Security Considerations

### Token Protection
- **Encryption**: DPAPI with CurrentUser scope prevents unauthorized access
- **File Storage**: `.dat` extension obscures plaintext JSON
- **Auto-Refresh**: Minimizes token lifetime exposure

### API Security
- **OAuth 2.0**: Industry-standard authorization protocol
- **Scopes**: Requests only necessary permissions (`read`, `activity:read_all`)
- **HTTPS**: All API calls use encrypted transport

### Configuration
- Client secrets stored in local `appsettings.json` (should be gitignored)
- Redirect URI limited to localhost for desktop app security

---

## Extension Points

### Adding New Features
1. **New Activity Types**: Extend `StravaActivity` model and update type filters
2. **Additional Stats**: Add methods to `StravaApiService` for custom aggregations
3. **UI Tabs**: Create new tab pages in Form1 for different data views
4. **Export Functionality**: Add CSV/Excel export from DataGridView
5. **Notifications**: Integrate toast notifications for new PRs

### API Enhancements
- Add rate limiting to respect Strava API quotas
- Implement caching layer to reduce API calls
- Add retry logic with exponential backoff
- Support for activity uploads/updates

---

## Dependencies

### NuGet Packages
- `System.Text.Json` - JSON serialization
- `System.Security.Cryptography` - DPAPI encryption
- .NET built-in packages (HttpClient, Windows Forms)

### External APIs
- **Strava API v3** - RESTful API for athlete data
  - Authentication: `https://www.strava.com/oauth/`
  - Activities: `https://www.strava.com/api/v3/athlete/activities`

---

## Configuration Requirements

### Prerequisites
1. Strava API application registered at [Strava Developers](https://www.strava.com/settings/api)
2. `appsettings.json` with valid ClientId, ClientSecret, and RedirectUri
3. Redirect URI configured as `http://localhost:8080/` in Strava app settings

### First-Time Setup
1. Create Strava API application
2. Copy credentials to `appsettings.json`
3. Build and run application
4. Click "Connect to Strava" to authorize
5. Tokens automatically managed thereafter

---

## Error Handling

### Graceful Degradation
- Missing configuration shows error dialog with guidance
- Network failures display user-friendly messages
- Token refresh failures prompt re-authorization
- Empty activity lists handled without crashes

### Logging
- Debug output for token operations
- Exception messages captured and displayed
- Progress indicators for long-running operations

---

## Future Improvements

### Potential Enhancements
1. **Database Integration**: Local SQLite for offline access and faster queries
2. **Charts/Graphs**: Visual analytics using charting libraries
3. **Training Plans**: Goal setting and progress tracking
4. **Social Features**: Kudos, comments, club integrations
5. **Multi-Athlete**: Support for multiple Strava accounts
6. **Settings UI**: Configuration management without editing JSON
7. **Background Sync**: Periodic automatic data refresh

---

