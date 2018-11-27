using System;
namespace BF_Test.Helpers
{
    public static class Constants
    {
        public const string RATES_CACHE_KEY = "RATES_CACHE_KEY";
        public const string ADMIN_REPEAT_INTERVAL_CALL_KEY = "ADMIN_REPEAT_INTERVAL_CALL_KEY";
        public const string TIME_FOR_NEXT_CALL_KEY = "TIME_FOR_NEXT_CALL_KEY";
        public const int DEFAULT_ADMIN_REPEAT_INTERVAL_CALL_VALUE = 100000;

        public const string API_KEY = "fb577531b0ac4fceb17d7e3dd5c33c3b";

        public static TimeSpan DEFAULT_CACHE_EXPIRATION = TimeSpan.FromDays(30);

        public const string TEST_ADMIN_AUTH_TOKEN = "admin";
    }
}
