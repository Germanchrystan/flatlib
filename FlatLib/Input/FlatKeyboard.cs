using Microsoft.Xna.Framework.Input;
using System;

namespace FlatLib.Input
{
    public sealed class FlatKeyboard
    {
        private static readonly Lazy<FlatKeyboard> lazy = new Lazy<FlatKeyboard>();
        public static FlatKeyboard Instance { get { return lazy.Value; } }

        private KeyboardState prevKeyboardState;
        private KeyboardState currKeyboardState;
        public FlatKeyboard()
        {
            this.prevKeyboardState = Keyboard.GetState();
            this.currKeyboardState = prevKeyboardState;
        }

        public void Update()
        {
            this.prevKeyboardState = this.currKeyboardState;
            this.currKeyboardState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return this.currKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyClicked(Keys key)
        {
            return this.currKeyboardState.IsKeyDown(key) && !this.prevKeyboardState.IsKeyDown(key);
        }
    }
}
