public class User
{
    public int IDUser { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public bool IsLocked { get; set; } = false;
}