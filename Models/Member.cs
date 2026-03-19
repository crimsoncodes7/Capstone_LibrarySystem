namespace Capstone_LibrarySystem.Models;

public class Member
{
    public int MemberID { get; }
    public string Name { get; }

    public Member(int memberId, string name)
    {
        MemberID = memberId;
        Name = name;
    }
}