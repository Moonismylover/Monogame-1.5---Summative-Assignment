using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Monogame_1._5___Summative_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum Screen
        {
            intro, 
            skit,
            outro
        }

        Screen screen;

        Texture2D background;

        Rectangle window;
        Rectangle bgRect;

        SpriteFont introText;

        Color bgColor = Color.DarkViolet;

        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screen = Screen.intro;

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            bgRect = new Rectangle(0, 0, window.Width, window.Height); 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("background");
            introText = Content.Load<SpriteFont>("IntroText");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            if (screen == Screen.intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.skit;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();
            
            if (screen == Screen.intro)
            {
                _spriteBatch.DrawString(introText, "Welcome to the play of 'Snape - The Third Wheel!'", new Vector2(50, 250), Color.White);
            }
            else if (screen == Screen.skit)
            {
                _spriteBatch.Draw(background, bgRect, Color.White);

            }
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
