using System;
using System.Collections.Generic;
using System.Text;

namespace AutomobileExpertSystem
{
    class FactManager
    {
        private FactDatabase factDatabase = new FactDatabase();
        public FactManager()
        {
            init();
        }

        public FactDatabase getFactDatabase()
        {
            return factDatabase;
        }

        private void init()
        {
            factDatabase.Add(new List<string>() { "шкп" }, new Fact("Нарушение в механизме синхронизации коробки передач."));
            factDatabase.Add(new List<string>() { "зввп", "нппвд" }, new Fact("Нарушение рычажного механизма."));
            factDatabase.Add(new List<string>() { "шдвп", "зпсош" }, new Fact("Ослаблены стопорные болты, удерживающие оконечную шестерню."));
            factDatabase.Add(new List<string>() { "зпсош", "шп" }, new Fact("Заедание, повреждение или ослабление торцевого подшипника."));
            factDatabase.Add(new List<string>() { "дндпп" }, new Fact("Повреждена ось сателлитов или ослаблены болты крепления оконечной шестерни."));
            factDatabase.Add(new List<string>() { "свп" }, new Fact("Износ или механическое повреждение коробки передач."));
            factDatabase.Add(new List<string>() { "икп", "нениш", "икпдс" }, new Fact("Низкое давление в шинах."));
            factDatabase.Add(new List<string>() { "икп", "нениш", "икпос" }, new Fact("Ненормальный развал колёс."));
            factDatabase.Add(new List<string>() { "икп", "нениш", "ицп" }, new Fact("Избыточное давление в шинах."));
            factDatabase.Add(new List<string>() { "нениш", "нериш" }, new Fact("Ненормально действует подвеска."));
            factDatabase.Add(new List<string>() { "ут" }, new Fact("Нарушена топливная система."));
            factDatabase.Add(new List<string>() { "чцвг", "нцм" }, new Fact("Требуется заменить масло."));
            factDatabase.Add(new List<string>() { "бцвг" }, new Fact("Требуется замена топливного фильтра."));
            factDatabase.Add(new List<string>() { "бцвг", "сд" }, new Fact("Повреждены головки клапанов."));
        }
    }
}
