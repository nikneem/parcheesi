using System;
using System.Text;

namespace HexMaster.Parcheesi.Common
{
    public static class Randomizer
    {
        private static Random _rnd;
        private  static string defaultPool = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GenerateSecret()
        {
            Seed();
            var secret = new StringBuilder();
            while (secret.Length < 64)
            {
                secret.Append(defaultPool.Substring(_rnd.Next(0, defaultPool.Length), 1));
            }

            return secret.ToString();
        }

        private  static void Seed()
        {
            if (_rnd != null)
            {
                _rnd=new Random(DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond);
            }
        }
    }
}
