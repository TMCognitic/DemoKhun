using System;

namespace DemoKhun.Models.Client.Entities
{
    public class Entity
    {
        public string Text { get; private set; }

        public Entity(string text)
        {
            Text = text;
        }
    }
}
