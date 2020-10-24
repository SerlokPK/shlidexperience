namespace DomainModels.Users
{
    public class UserStatus
    {
        private const string _active = "Active";
        private const string _blocked = "Blocked";
        private const string _deleted = "Deleted";
        private const string _unknown = "Unknown";

        public string Status { get; set; }
        public string Name { get; set; }
        public UserStatus()
        {

        }

        public UserStatus(string status, string name)
        {
            Status = status;
            Name = name;
        }

        public static UserStatus Active = new UserStatus("A", _active);

        public static UserStatus Blocked = new UserStatus("B", _blocked);

        public static UserStatus Deleted = new UserStatus("D", _deleted);

        public static UserStatus Unknown = new UserStatus("X", _unknown);

        public static UserStatus GetStatus(string status)
        {
            switch (status)
            {
                case "A":
                    return Active;
                case "B":
                    return Blocked;
                case "D":
                    return Deleted;
                default:
                    return Unknown;
            }
        }
    }
}
