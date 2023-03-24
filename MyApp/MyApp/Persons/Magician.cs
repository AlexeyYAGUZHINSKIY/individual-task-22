namespace MyApp;

//персонаж Маг
public class Magician : Person
{
    //конструктор для создания по умолчанию Мага
    public Magician()
    {
        //присваивается навык Исцеление
        Skill = Skills.Healing;
        //по умолчанию задаем количество жизней
        Live = 3;
        //по умолчанию задаем количество очков здоровья
        Health = 5;
        //по умолчанию задаем количество очков атаки
        AttackPoints = 1;
        //пустой список бонусных вещей
        BonusThings = new List<BonusThing>() { };
    }
    
    //конструктор для создания Мага с бонусной вещью
    public Magician(BonusThing bonusThing)
    {
        //присваивается навык Исцеление
        Skill = Skills.Healing;
        //по умолчанию задаем количество жизней
        Live = 3;
        //по умолчанию задаем количество очков здоровья
        Health = 5;
        //по умолчанию задаем количество очков атаки
        AttackPoints = 1;
        //добавляем бронусную вещь
        BonusThings = new List<BonusThing>() { bonusThing };
    }

    //метод применения навыка Исцеление
    public void Heal()
    {
        //увеличивает здоровье на 3 очка
        this.Health += 3;
    }

    public void MakeMove(MoveType moveType, Person person)
    {
        switch (moveType)
        {
            case MoveType.Attack:
            {
                //посчитаем наши очки атаки
                var attackPoints = this.AttackPoints;
                //выберем все вещи с бонусом на атаку
                var bonusThings = this.BonusThings.Where(x => x.Property == Property.Attack);
                foreach (var bs in BonusThings)
                {
                    //добавим их бонус к нашим очкам атаки
                    attackPoints += bs.Point;

                }

                //атакуем противника, снимая из очков его здоровья 
                if (person.Health >= attackPoints)
                {
                    person.Health -= attackPoints;
                }

                //если очков здоровья не хватает - отнимаем одну жизнь
                person.Live--;
                break;
            }
            case MoveType.Skill:
            {
                //применяем метод навыка
                Heal();
                break;
            }
            case MoveType.Pass:
            {
                //пропускаем ход, ничего не делая
                break;
            }
        }
    }
}