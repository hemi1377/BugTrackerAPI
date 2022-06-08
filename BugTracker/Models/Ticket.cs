namespace BugTracker.Models
{
    public class Ticket
    {
        public string fullName;
        public int Id { get; set; }

        public string Title { get; set; }   

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Completed { get; set; } 

    }
}
