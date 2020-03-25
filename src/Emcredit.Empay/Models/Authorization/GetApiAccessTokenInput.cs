namespace Emcredit.Empay.Models.Authorization
{
    public class GetApiAccessTokenInput
    {
        public EmpaySettings EmpaySettings { get; set; }
        public string Scope { get; set; }
    }
}