namespace MyApp;

//базовый класс для всех персонажей  
public abstract class Person : IPerson
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Live { get; set; }
    public Skills Skill { get; set; }
    public int AttackPoints { get; set; }
    public List<BonusThing> BonusThings { get; set; }
}