using System;
using System.Collections.Generic;
using System.Text;

namespace StravaWinForm.Models
{
    public class StravaTokenResponse
    {
        public string access_token { get; set; } = string.Empty;
        public string refresh_token { get; set; } = string.Empty;
        public long expires_at { get; set; }
        public int expires_in { get; set; }
    }
}
