using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitHiker.Api.Models
{
    public class UserSecurity
    {
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public int PasswordAlgorithm { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime AllowLoginAfterDate { get; set; }
        public DateTime DisableLoginAfterDate { get; set; }
        public int FailedLoginAttempts { get; set; }
        public string PasswordResetToken { get; set; }
        public string PasswordResetTokenExpirationDate { get; set; }
        public DateTime LastPasswordChangeDate { get; set; }
        public DateTime LastSuccessfulLoginDate { get; set; }
        public string LastSuccessfulLoginIp { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}