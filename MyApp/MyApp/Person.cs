namespace MyApp;

//класс персонажа
public class Person
{
    //наименование персонажа
    public string Name { get; set; }
    //очки здоровья
    public int Health { get; set; }
    //количество жизней
    public int Live { get; set; }
    //навык персонажа
    public Skills Skill { get; set; }
}