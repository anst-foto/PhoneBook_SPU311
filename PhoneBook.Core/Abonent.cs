namespace PhoneBook.Core;

public class Abonent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public override string ToString() => $"{Name} {Phone}";
}