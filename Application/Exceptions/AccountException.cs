namespace Application.Exceptions
{
    public class AccountException : ApplicationException
    {
        private AccountException(string message)
            : base(message) { }

        public static AccountException LoginAlreadyExists(string login)
        {
            return new AccountException($"An account with the same login {login} already exists.");
        }

        public static AccountException AccountDoesNotExist(string login, string password)
        {
            return new AccountException($"The login {login} or password {password} is incorrect.");
        }
    }
}
