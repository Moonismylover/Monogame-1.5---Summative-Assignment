using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
            snapeInterview,
            julietGossipWithDemo,
            romeosNewGirl,
            outro
        }

        Screen screen;

        Texture2D newsbg;
        Texture2D hellbg;
        Texture2D beachbg;
        Texture2D snape;
        Texture2D romeo;
        Texture2D juliet;
        Texture2D 

        Rectangle window;
        Rectangle snapeRect;
        Rectangle romeoRect;
        Rectangle julietRect;

        Vector2 snapeSpeed;
        Vector2 romeoSpeed;
        Vector2 julietSpeed;

        SpriteFont introText;

        SoundEffect themeMusic;
        SoundEffectInstance themeInstance;

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

            snapeRect = new Rectangle(-230, 230, 230, 380);

            snapeSpeed = new Vector2(2, 0);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            newsbg = Content.Load<Texture2D>("News");
            hellbg = Content.Load<Texture2D>("Hell");
            beachbg = Content.Load<Texture2D>("Beach");
            romeo = Content.Load<Texture2D>("Romeo");
            juliet = Content.Load<Texture2D>("Juliet");
            snape = Content.Load<Texture2D>("Snape");
            introText = Content.Load<SpriteFont>("IntroText");
            themeMusic = Content.Load<SoundEffect>("themeMusic");
            themeInstance = themeMusic.CreateInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.Window.Title = mouseState.Position.ToString();

            mouseState = Mouse.GetState();

            if (screen == Screen.intro)
            {
                themeInstance.Play();
                if (mouseState.LeftButton == ButtonState.Pressed && IsActive)
                {
                    themeInstance.Stop();
                    screen = Screen.snapeInterview;
                }
            }
            else if (screen == Screen.snapeInterview)
            {
                snapeRect.X += (int)snapeSpeed.X;
                snapeRect.Y += (int)snapeSpeed.Y;
                if (snapeRect.X == 400)
                {
                    snapeSpeed.X = 0;
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
                _spriteBatch.DrawString(introText, "Welcome to the play of ", new Vector2(190, 200), Color.White);
                _spriteBatch.DrawString(introText, "'Interview with Muggles!'", new Vector2(175, 250), Color.White);
                _spriteBatch.DrawString(introText, "Please click to continue!", new Vector2(190, 300), Color.White);
            }
            else if (screen == Screen.snapeInterview)
            {
                _spriteBatch.Draw(newsbg, window, Color.White);
                _spriteBatch.Draw(snape, snapeRect, Color.White);
            }
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
//Lesson 1-5 Summative Animation

//You are to use skills learned from the lessons (1-5) that we have covered up to this point to create some
//sort of animation. I recommend picking a favourite TV show, movie or game, but you may choose to do
//anything that is school appropriate. You must use an enumeration in order to track which screen your
//animation is on.
//Your animation must have the following screens (at a minimum):
//1.Intro / Title Screen
//a.This may just be a static image if you like.
//b.Play some background music and indicate to the user that they can proceed to the main
//animation. They should be able to do this by hitting a key(s) of your choice.
//i. When the audio stops playing, the animation should advance if the user decides
//to wait.
//2. Main Animation Screen(s)
//a. There needs to be some sort of animation here. What it looks like is entirely up to you.
//Experiment, try some new things.I’m looking for something interesting/creative.
//i. For full marks, there needs to be more than 1 phase in this animation.
//b. This animation may go on forever and require the user to end it or may run to a
//conclusion and end itself.
//c. For a Level 4+ there needs to be more than something basic repeating itself.
//d. You may wish to use some the following (it is not necessary to do all of these things):
//i.Sound Effects
//ii.Music
//iii. Randomness
//iv. Response to user input (this is not a requirement for a level 4)
//v. Text
//3. End Screen
//a. After the main animation is done, or the user has chosen to end it have some type of
//farewell screen with some text as credits (do this with text).
//b. The program can terminate after a set amount or time, or by having the user choose to
//end it. Remember that if the user needs to do something there must be instructions.

//Things you will need to do:
//• Plan out what your theme will be.
//• Plan out what will be on your 3 (or more) screens. Set up an enumeration to draw and run the
//appropriate logic at the right time.
//o Your window may change sizes between your title, main and ending screen .
//• Use photoshop, or https://www.photopea.com/ to crop, resize, and give images transparent
//backgrounds.
//o The less scaling your program has to do the better.
//o It makes a big difference having properly edited images.
//• Use Audacity to convert and edit sound files to add to your animation.
//• Keep your code organized.
//o Be consistent when naming textures, sounds, rectangles, etc.
//o Be consistent about where and how you initialize content.
//o Use white space and comments in your code where appropriate.
