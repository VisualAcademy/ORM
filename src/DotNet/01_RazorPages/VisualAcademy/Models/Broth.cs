namespace VisualAcademy.Models
{
    /// <summary>
    /// 국물
    /// </summary>
    public class Broth
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool IsVegan { get; set; } = false;

        public Broth()
        {
            // Empty
        }
        public Broth(string name)
        {
            Name = name;
        }
    }
}
