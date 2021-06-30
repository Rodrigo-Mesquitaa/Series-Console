using Series.Enums;

namespace Series.Class
{
    public class Serie : BaseEntity
    {
        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Gender gender, string title, string description, int year)
        {
            Id = id;
            Gender = gender;
            Title = title;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public string ReturnTitle()
        {
            return Title;
        }

        public int ReturnId()
        {
            return Id;
        }

        public bool ReturnDeleted()
        {
            return Deleted;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
