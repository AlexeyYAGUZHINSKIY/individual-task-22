namespace MyApp;

//класс вещи, которые дают бонусы
public class BonusThing
{
    //Id вещи
    public int Id { get; set; }
    //свойство, на которое вещь дает бонус
    public Property Property { get; set; }
    //количество очков, на которое увеличивается бонусное свойство
    public int Point { get; set; }
}