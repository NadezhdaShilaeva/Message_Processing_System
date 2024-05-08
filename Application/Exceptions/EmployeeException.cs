namespace Application.Exceptions
{
    public class EmployeeException : ApplicationException
    {
        private EmployeeException(string message)
            : base(message) { }

        public static EmployeeException SameManagers(Guid managerId, Guid otherManagerId)
        {
            return new EmployeeException($"The managers {managerId} and {otherManagerId} is the same.");
        }

        public static EmployeeException AlreadyHasManager(Guid managerId)
        {
            return new EmployeeException($"The employee {managerId} already has manager.");
        }
    }
}
