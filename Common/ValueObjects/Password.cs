using Common.ExtensionMethods;
using HexMaster.Parcheesi.Common.Base;
using HexMaster.Parcheesi.Common.Infrastructure.Enums;

namespace HexMaster.Parcheesi.Common.ValueObjects
{
    public class Password : TrackingStateBase
    {
        public string Passwd { get; private set; }
        public string Secret { get; }

        private void SetPassword(string value)
        {
            SetState(TrackingState.Touched);
            var newPassword = value.Hash(Secret);
            if (!Equals(Passwd, newPassword))
            {
                Passwd = newPassword;
                SetState(TrackingState.Modified);
            }
        }

        public Password(string password, string secret)
        {
            Passwd = password;
            Secret = secret;
        }

        public Password(string readablePassword) : base(TrackingState.Added)
        {
            Secret = Randomizer.GenerateSecret();
            Passwd = readablePassword.Hash(Secret);
        }

    }
}
