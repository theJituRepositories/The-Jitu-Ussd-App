using library_service;

class Program
{
    static void Main(string[] args)
    {
        // Set the desired path
        //PathManager.Path = @"C:\Users\Public";
        User_menu new_user = new User_menu();
        new_user.UserMenu();
    }
}