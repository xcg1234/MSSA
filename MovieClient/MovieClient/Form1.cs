using System.ComponentModel.Design.Serialization;
using System.Net.Http.Json;
using static MovieClient.Weather;

namespace MovieClient
{
    public partial class Form1 : Form
    {
        HttpClient movieClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            movieClient.BaseAddress = new Uri("http://localhost:5010/");
        }
        //btnloadclick
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadMoviesAsync();
        }

        private async Task LoadMoviesAsync()
        {
            try
            {

                var response = await movieClient.GetAsync("api/Movies");
                if (response.IsSuccessStatusCode)
                {
                    var movieList = await response.Content.ReadFromJsonAsync<List<Movie>>();
                    moviesGrid.DataSource = movieList;
                }
                else
                {
                    MessageBox.Show($"Failed to load movies: {response.ReasonPhrase}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryReadMovie(out var newMovie))
            {
                return;
            }

            try
            {
                var response = await movieClient.PostAsJsonAsync("api/Movies", newMovie);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Movie added successfully!");
                    await LoadMoviesAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to add movie: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!TryReadMovie(out var movieToUpdate))
            {
                return;
            }

            try
            {
                var response = await movieClient.PutAsJsonAsync($"api/Movies/{movieToUpdate.Id}", movieToUpdate);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Movie updated successfully!");
                    await LoadMoviesAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to update movie: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text.Trim(), out var id) || id <= 0)
            {
                MessageBox.Show("Enter a valid Id to delete.");
                return;
            }

            try
            {
                var response = await movieClient.DeleteAsync($"api/Movies/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Movie deleted successfully!");
                    await LoadMoviesAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to delete movie: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool TryReadMovie(out Movie movie)
        {
            movie = new Movie();

            if (!int.TryParse(txtId.Text.Trim(), out var id) || id <= 0)
            {
                MessageBox.Show("Enter a valid Id.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDirector.Text))
            {
                MessageBox.Show("Director is required.");
                return false;
            }

            if (!int.TryParse(txtReleaseYear.Text.Trim(), out var releaseYear))
            {
                MessageBox.Show("Enter a valid Release Year.");
                return false;
            }

            movie = new Movie
            {
                Id = id,
                Title = txtTitle.Text.Trim(),
                Director = txtDirector.Text.Trim(),
                ReleaseYear = releaseYear
            };

            return true;
        }

        private void moviesGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (moviesGrid.CurrentRow?.DataBoundItem is not Movie selectedMovie)
            {
                return;
            }

            txtId.Text = selectedMovie.Id.ToString();
            txtTitle.Text = selectedMovie.Title;
            txtDirector.Text = selectedMovie.Director;
            txtReleaseYear.Text = selectedMovie.ReleaseYear.ToString();
        }

        private void btn_GetWeather(object sender, EventArgs e)
        {
            var weatherClient = new HttpClient();
            weatherClient.BaseAddress = new Uri("https://api.tomorrow.io/v4/weather/realtime?location=10004%20US&apikey=REMOVED");
            var response = weatherClient.GetAsync(weatherClient.BaseAddress).Result;
            Root? root = response.Content.ReadFromJsonAsync<Root>().Result;
            if (response.IsSuccessStatusCode && root != null)
            {
                MessageBox.Show($"Current temperature in {root.location.name} is {root.data.values.temperature}°„C");
            }
            else
            {
                MessageBox.Show($"Failed to get weather: {response.ReasonPhrase}");
            }
        }
    }
}
