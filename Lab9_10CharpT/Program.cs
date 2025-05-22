using System;
using System.Collections.Generic;

public delegate void MyEventHandler(int day, List<string> events);

class EventSchedule
{

    public event MyEventHandler OnDayEvents;

    private Dictionary<int, List<string>> eventsByDay;

    public EventSchedule()
    {
    
        eventsByDay = new Dictionary<int, List<string>>
        {
            { 1, new List<string> {
                "Ремонт центральної дороги: затори на годину",
                "Відкриття нової кав'ярні на вулиці Шевченка",
                "Запуск системи розумного освітлення в місті",
                "Проведення майстер-класу з йоги в парку"
            }},
            { 2, new List<string> {
                "Зустріч у міській раді щодо безпеки на дорогах",
                "Працюють фонтани в парку ім. Лесі Українки",
                "Концерт місцевого рок-гурту на площі",
                "Відкриття дитячого майданчика на вулиці Пушкіна"
            }},
            { 3, new List<string> {
                "Відкриття виставки сучасного мистецтва в музеї",
                "Проведення щотижневого ринку на головній площі",
                "Оновлення вуличних лавок у парку",
                "Показ вуличного театру на центральній алеї"
            }},
            { 4, new List<string> {
                "Зимова ярмарка розпочинається в центрі міста",
                "Оновлення тротуарів біля університету",
                "Запуск нової велодоріжки вздовж річки",
                "Відкриття кінотеатру під відкритим небом"
            }},
            { 5, new List<string> {
                "Проведення марафону на підтримку здорового способу життя",
                "Закриття мосту для ремонту на вихідні",
                "Публічні читання поезії у міській бібліотеці",
                "Виступ вуличних музикантів на пішохідній зоні"
            }},
            { 6, new List<string> {
                "Вуличний фестиваль їжі: дегустація страв із різних країн",
                "Показ фільму під відкритим небом у парку",
                "Концерт джазової музики на набережній",
                "Ярмарок ремесел на площі Свободи"
            }},
            { 7, new List<string> {
                "Оголошення про новий громадський транспорт",
                "Посадка дерев у міському сквері",
                "Початок ремонтних робіт у дитячому садку",
                "Відкриття нової спортивної зони для молоді"
            }}
        };
    }

    public void Run()
    {
        for (int day = 1; day <= 7; day++)
        {
            if (eventsByDay.ContainsKey(day) && OnDayEvents != null)
            {
                OnDayEvents(day, eventsByDay[day]);
            }
        }
    }
}

class Program
{

    static void PrintDayEvents(int day, List<string> events)
    {
        Console.WriteLine($"--- День {day} ---");
        foreach (var ev in events)
        {
            Console.WriteLine(ev);
        }
        Console.WriteLine("----------------------------------------\n");
    }

    static void Main(string[] args)
    {
        EventSchedule schedule = new EventSchedule();

        schedule.OnDayEvents += PrintDayEvents;

        schedule.Run();

        Console.ReadKey();
    }
}
