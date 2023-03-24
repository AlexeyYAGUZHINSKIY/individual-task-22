namespace MyApp;

//интерфейс для персонажей
public interface IPerson
{
    //наименование персонажа
    public string Name { get; set; }
    //очки здоровья
    public int Health { get; set; }
    //количество жизней
    public int Live { get; set; }
    //навык персонажа
    public Skills Skill { get; set; }
    //очки атаки персонажа
    public int AttackPoints { get; set; }
    //список вещей, которые дают бонусы
    public List<BonusThing> BonusThings { get; set; }

    //метод, который позволяет сделать ход
    public void MakeMove(MoveType moveType, Person person){}
}