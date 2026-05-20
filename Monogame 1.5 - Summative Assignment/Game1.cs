using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Http.Headers;
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
            julietGossipWithDemon,
            romeosNewGirl,
            outro
        }

        Screen screen;

        bool timerStart = false;
        bool dialogueOne = false;
        bool dialogueTwo = false;
        bool dialogueThree = false;
        bool dialogueFour = false;
        bool dialogueFive = false;

        bool songPlayed = false;

        Texture2D introBg;
        Texture2D newsBg;
        Texture2D hellBg;
        Texture2D beachBg;
        Texture2D outroBg;

        Texture2D snape;
        Rectangle snapeRect;
        Texture2D romeo;
        Rectangle romeoRect;
        Texture2D juliet;
        Rectangle julietRect;
        Texture2D demon;
        Rectangle demonRect;
        Texture2D romeosNewGirl;
        Rectangle romeosNewGirlRect;

        Texture2D skipButton;
        Rectangle skipButtonRect;

        Texture2D sceneOneDialogueOne;
        Rectangle sceneOneDialogueOneRect;
        Texture2D sceneOneDialogueTwo;
        Rectangle sceneOneDialogueTwoRect;
        Texture2D sceneOneDialogueThree;
        Rectangle sceneOneDialogueThreeRect;
        Texture2D sceneOneDialogueFour;
        Rectangle sceneOneDialogueFourRect;
        Texture2D sceneOneDialogueFive;
        Rectangle sceneOneDialogueFiveRect;

        Texture2D sceneTwoDialogueOne;
        Rectangle sceneTwoDialogueOneRect;
        Texture2D sceneTwoDialogueTwo;
        Rectangle sceneTwoDialogueTwoRect;
        Texture2D sceneTwoDialogueThree;
        Rectangle sceneTwoDialogueThreeRect;
        Texture2D sceneTwoDialogueFour;
        Rectangle sceneTwoDialogueFourRect;
        Texture2D sceneTwoDialogueFive;
        Rectangle sceneTwoDialogueFiveRect;

        Texture2D sceneThreeDialogueOne;
        Rectangle sceneThreeDialogueOneRect;
        Texture2D sceneThreeDialogueTwo;
        Rectangle sceneThreeDialogueTwoRect;
        Texture2D sceneThreeDialogueThree;
        Rectangle sceneThreeDialogueThreeRect;
        Texture2D sceneThreeDialogueFour;
        Rectangle sceneThreeDialogueFourRect;
        Texture2D sceneThreeDialogueFive;
        Rectangle sceneThreeDialogueFiveRect;

        Rectangle window;

        Vector2 snapeSpeed;
        Vector2 julietSpeed;
        Vector2 demonSpeed;

        float seconds;

        SpriteFont introText;

        SoundEffect themeMusic;
        SoundEffectInstance themeInstance;
        SoundEffect sceneOneAudio;
        SoundEffectInstance sceneOneAudioInstance;
        SoundEffect sceneTwoAudio;
        SoundEffectInstance sceneTwoAudioInstance;
        SoundEffect sceneThreeAudio;
        SoundEffectInstance sceneThreeAudioInstance;

        Color bgColor = Color.DarkViolet;

        MouseState mouseState;
        KeyboardState keyboardState;

        MouseState previousMouseState;

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

            snapeRect = new Rectangle(-230, 230, 200, 350);
            sceneOneDialogueOneRect = new Rectangle(270, 150, 200, 200);
            sceneOneDialogueTwoRect = new Rectangle(270, 150, 200, 200);
            sceneOneDialogueThreeRect = new Rectangle(240, 150, 200, 200);
            sceneOneDialogueFourRect = new Rectangle(0, 180, 200, 200);
            sceneOneDialogueFiveRect = new Rectangle(230, 290, 200, 150);

            julietRect = new Rectangle(800, 200, 250, 400);
            demonRect = new Rectangle(100, -250, 200, 250);
            sceneTwoDialogueOneRect = new Rectangle(270, 70, 200, 200);
            sceneTwoDialogueTwoRect = new Rectangle(390, 90, 200, 200);
            sceneTwoDialogueThreeRect = new Rectangle(10, 50, 200, 200);
            sceneTwoDialogueFourRect = new Rectangle(390, 130, 200, 200);
            sceneTwoDialogueFiveRect = new Rectangle(420, 70, 200, 150);

            sceneThreeDialogueOneRect = new Rectangle(120, 70, 200, 200);
            sceneThreeDialogueTwoRect = new Rectangle(160, 70, 150, 150);
            sceneThreeDialogueThreeRect = new Rectangle(560, 60, 150, 150);
            sceneThreeDialogueFourRect = new Rectangle(250, 60, 170, 170);
            sceneThreeDialogueFiveRect = new Rectangle(150, 90, 170, 170);

            skipButtonRect = new Rectangle(10, 10, 140, 50);

            snapeSpeed = new Vector2(3, 0);
            julietSpeed = new Vector2(-3, 0);
            demonSpeed = new Vector2(0, 3);

            romeoRect = new Rectangle(260, 220, 120, 310);
            romeosNewGirlRect = new Rectangle(290, 215, 310, 310);

            seconds = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introBg = Content.Load<Texture2D>("IntroBackground");
            newsBg = Content.Load<Texture2D>("News");
            hellBg = Content.Load<Texture2D>("Hell");
            beachBg = Content.Load<Texture2D>("Beach");
            outroBg = Content.Load<Texture2D>("Goodbye");

            romeo = Content.Load<Texture2D>("Romeo");
            juliet = Content.Load<Texture2D>("Juliet");
            snape = Content.Load<Texture2D>("Snape");
            demon = Content.Load<Texture2D>("Demon");
            romeosNewGirl = Content.Load<Texture2D>("Romeos_new_girl");

            introText = Content.Load<SpriteFont>("IntroText");

            themeMusic = Content.Load<SoundEffect>("themeMusic");
            themeInstance = themeMusic.CreateInstance();
            sceneOneAudio = Content.Load<SoundEffect>("sceneoneaudio");
            sceneOneAudioInstance = sceneOneAudio.CreateInstance();
            sceneTwoAudio = Content.Load<SoundEffect>("scenetwoaudio");
            sceneTwoAudioInstance = sceneTwoAudio.CreateInstance();
            sceneThreeAudio = Content.Load<SoundEffect>("scenethreeaudio");
            sceneThreeAudioInstance = sceneThreeAudio.CreateInstance();

            skipButton = Content.Load<Texture2D>("skip");

            sceneOneDialogueOne = Content.Load<Texture2D>("scene_1_dialogue_1");
            sceneOneDialogueTwo = Content.Load<Texture2D>("scene_1_dialogue_2");
            sceneOneDialogueThree = Content.Load<Texture2D>("scene_1_dialogue_3");
            sceneOneDialogueFour = Content.Load<Texture2D>("scene_1_dialogue_4");
            sceneOneDialogueFive = Content.Load<Texture2D>("scene_1_dialogue_5");

            sceneTwoDialogueOne = Content.Load<Texture2D>("scene_2_dialogue_1");
            sceneTwoDialogueTwo = Content.Load<Texture2D>("scene_2_dialogue_2");
            sceneTwoDialogueThree = Content.Load<Texture2D>("scene_2_dialogue_3");
            sceneTwoDialogueFour = Content.Load<Texture2D>("scene_2_dialogue_4");
            sceneTwoDialogueFive = Content.Load<Texture2D>("scene_2_dialogue_5");

            sceneThreeDialogueOne = Content.Load<Texture2D>("scene_3_dialogue_1");
            sceneThreeDialogueTwo = Content.Load<Texture2D>("scene_3_dialogue_2");
            sceneThreeDialogueThree = Content.Load<Texture2D>("scene_3_dialogue_3");
            sceneThreeDialogueFour = Content.Load<Texture2D>("scene_3_dialogue_4");
            sceneThreeDialogueFive = Content.Load<Texture2D>("scene_3_dialogue_5");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            this.Window.Title = mouseState.Position.ToString();

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (screen == Screen.intro)
            {
                if (!songPlayed)
                {
                    themeInstance.Play();
                    songPlayed = true;
                }

                if (keyboardState.IsKeyDown(Keys.Space) && IsActive)
                {
                    themeInstance.Stop();
                    sceneOneAudioInstance.Play();

                    screen = Screen.snapeInterview;
                    seconds = 0;
                }
                else if (themeInstance.State == SoundState.Stopped)
                {
                    screen = Screen.snapeInterview;
                    sceneOneAudioInstance.Play();
                    seconds = 0;
                }
            }
            else if (screen == Screen.snapeInterview)
            {
                snapeRect.X += (int)snapeSpeed.X;

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && skipButtonRect.Contains(mouseState.Position))
                {
                    seconds = 0;
                    timerStart = false;

                    dialogueOne = false;
                    dialogueTwo = false;
                    dialogueThree = false;
                    dialogueFour = false;
                    dialogueFive = false;

                    sceneOneAudioInstance.Stop();
                    sceneTwoAudioInstance.Play();

                    screen = Screen.julietGossipWithDemon;
                }

                if (snapeRect.X >= 400)
                {
                    snapeRect.X = 400;
                    snapeSpeed.X = 0;

                    if (!timerStart)
                    {
                        seconds = 0;
                        timerStart = true;
                    }

                    if (seconds >= 1 && !dialogueOne)
                    {
                        dialogueOne = true;
                    }
                    else if (seconds >= 4 && !dialogueTwo)
                    {
                        dialogueTwo = true;
                    }
                    else if (seconds >= 8 && !dialogueThree)
                    {
                        dialogueThree = true;
                    }
                    else if (seconds >= 12 && !dialogueFour)
                    {
                        dialogueFour = true;
                    }
                    else if (seconds >= 16 && !dialogueFive)
                    {
                        dialogueFive = true;
                    }

                    if (dialogueFive && seconds >= 21)
                    {
                        seconds = 0;
                        timerStart = false;

                        dialogueOne = false;
                        dialogueTwo = false;
                        dialogueThree = false;
                        dialogueFour = false;
                        dialogueFive = false;

                        sceneOneAudioInstance.Stop();
                        sceneTwoAudioInstance.Play();

                        screen = Screen.julietGossipWithDemon;
                    }
                }
            }
            else if (screen == Screen.julietGossipWithDemon)
            {
                julietRect.X += (int)julietSpeed.X; 
                demonRect.Y += (int)demonSpeed.Y;

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && skipButtonRect.Contains(mouseState.Position))
                {
                    seconds = 0;
                    timerStart = false;

                    dialogueOne = false;
                    dialogueTwo = false;
                    dialogueThree = false;
                    dialogueFour = false;
                    dialogueFive = false;

                    sceneTwoAudioInstance.Stop();
                    sceneThreeAudioInstance.Play();

                    screen = Screen.romeosNewGirl;
                }

                if (julietRect.X <= 500)
                {
                    julietRect.X = 500;
                    julietSpeed.X = 0;
                }

                if (demonRect.Y >= 100)
                {
                    demonRect.Y = 100;
                    demonSpeed.Y = 0;

                    if (!timerStart)
                    {
                        seconds = 0;
                        timerStart = true;
                    }

                    if (seconds >= 1 && !dialogueOne)
                    {
                        dialogueOne = true;
                    }
                    else if (seconds >= 4 && !dialogueTwo)
                    {
                        dialogueTwo = true;
                    }
                    else if (seconds >= 8 && !dialogueThree)
                    {
                        dialogueThree = true;
                    }
                    else if (seconds >= 12 && !dialogueFour)
                    {
                        dialogueFour = true;
                    }
                    else if (seconds >= 16 && !dialogueFive)
                    {
                        dialogueFive = true;
                    }

                    if (dialogueFive && seconds >= 21)
                    {
                        seconds = 0;
                        timerStart = false;

                        dialogueOne = false;
                        dialogueTwo = false;
                        dialogueThree = false;
                        dialogueFour = false;
                        dialogueFive = false;

                        sceneTwoAudioInstance.Stop();
                        sceneThreeAudioInstance.Play();

                        screen = Screen.romeosNewGirl;
                    }
                }
             }
            else if (screen == Screen.romeosNewGirl)
            {
                snapeRect.X += (int)snapeSpeed.X;
                julietRect.X += (int)julietSpeed.X;

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && skipButtonRect.Contains(mouseState.Position))
                {
                    seconds = 0;

                    sceneThreeAudioInstance.Stop();
                    themeInstance.Play();

                    screen = Screen.outro;
                }

                if (julietRect.X <= 550)
                {
                    julietRect.X = 550;
                    julietSpeed.X = 0;
                }

                if (snapeRect.X >= 50)
                {
                    snapeRect.X = 50;
                    snapeSpeed.X = 0;

   
                    if (seconds >= 1 && !dialogueOne)
                    {
                        dialogueOne = true;
                    }
                    else if (seconds >= 4 && !dialogueTwo)
                    {
                        dialogueTwo = true;
                    }
                    else if (seconds >= 8 && !dialogueThree)
                    {
                        dialogueThree = true;
                    }
                    else if (seconds >= 12 && !dialogueFour)
                    {
                        dialogueFour = true;
                    }
                    else if (seconds >= 16 && !dialogueFive)
                    {
                        dialogueFive = true;
                    }
                }

                if (dialogueFive && seconds >= 21)
                {
                    seconds = 0;

                    sceneThreeAudioInstance.Stop();
                    themeInstance.Play();

                    screen = Screen.outro;
                }
            }
            else if (screen == Screen.outro)
            {
                if (seconds > 5)
                {
                    themeInstance.Stop();
                    Exit();
                }
            }

            previousMouseState = mouseState;    

            base.Update(gameTime);
        
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();

            if (screen == Screen.intro)
            {
                _spriteBatch.Draw(introBg, window, Color.White);
                _spriteBatch.DrawString(introText, "Welcome to the play of ", new Vector2(140, 200), Color.Black);
                _spriteBatch.DrawString(introText, "'Interview with Muggles!'", new Vector2(140, 250), Color.Black);
                _spriteBatch.DrawString(introText, "Please press space to \ncontinue!", new Vector2(140, 300), Color.Black);
            }
            else if (screen == Screen.snapeInterview)
            {
                _spriteBatch.Draw(newsBg, window, Color.White);
                _spriteBatch.Draw(skipButton, skipButtonRect, Color.White);
                _spriteBatch.Draw(snape, snapeRect, Color.White);

                if (dialogueFive)
                {
                    _spriteBatch.Draw(sceneOneDialogueFive, sceneOneDialogueFiveRect, Color.White);
                }
                else if (dialogueFour)
                {
                    _spriteBatch.Draw(sceneOneDialogueFour, sceneOneDialogueFourRect, Color.White);
                }
                else if (dialogueThree)
                {
                    _spriteBatch.Draw(sceneOneDialogueThree, sceneOneDialogueThreeRect, Color.White);
                }
                else if (dialogueTwo)
                {
                    _spriteBatch.Draw(sceneOneDialogueTwo, sceneOneDialogueTwoRect, Color.White);
                }
                else if (dialogueOne)
                {
                    _spriteBatch.Draw(sceneOneDialogueOne, sceneOneDialogueOneRect, Color.White);
                }
            }

            else if (screen == Screen.julietGossipWithDemon)
            {
                _spriteBatch.Draw(hellBg, window, Color.White);
                _spriteBatch.Draw(skipButton, skipButtonRect, Color.White);
                _spriteBatch.Draw(juliet, julietRect, Color.White);
                _spriteBatch.Draw(demon, demonRect, Color.White);

                if (dialogueFive)
                {
                    _spriteBatch.Draw(sceneTwoDialogueFive, sceneTwoDialogueFiveRect, Color.White);
                }
                else if (dialogueFour)
                {
                    _spriteBatch.Draw(sceneTwoDialogueFour, sceneTwoDialogueFourRect, Color.White);
                }
                else if (dialogueThree)
                {
                    _spriteBatch.Draw(sceneTwoDialogueThree, sceneTwoDialogueThreeRect, Color.White);
                }
                else if (dialogueTwo)
                {
                    _spriteBatch.Draw(sceneTwoDialogueTwo, sceneTwoDialogueTwoRect, Color.White);
                }
                else if (dialogueOne)
                {
                    _spriteBatch.Draw(sceneTwoDialogueOne, sceneTwoDialogueOneRect, Color.White);
                }
            }

            else if (screen == Screen.romeosNewGirl)  
            {
                _spriteBatch.Draw(beachBg, window, Color.White);
                _spriteBatch.Draw(skipButton, skipButtonRect, Color.White);
                _spriteBatch.Draw(romeosNewGirl, romeosNewGirlRect, Color.White);
                _spriteBatch.Draw(romeo, romeoRect, Color.White);
                _spriteBatch.Draw(juliet, julietRect, Color.White);
                _spriteBatch.Draw(snape, snapeRect, Color.White);

                if (dialogueFive)
                {
                    _spriteBatch.Draw(sceneThreeDialogueFive, sceneThreeDialogueFiveRect, Color.White);
                }
                else if (dialogueFour)
                {
                    _spriteBatch.Draw(sceneThreeDialogueFour, sceneThreeDialogueFourRect, Color.White);
                }
                else if (dialogueThree)
                {
                    _spriteBatch.Draw(sceneThreeDialogueThree, sceneThreeDialogueThreeRect, Color.White);
                }
                else if (dialogueTwo)
                {
                    _spriteBatch.Draw(sceneThreeDialogueTwo, sceneThreeDialogueTwoRect, Color.White);
                }
                else if (dialogueOne)
                {
                    _spriteBatch.Draw(sceneThreeDialogueOne, sceneThreeDialogueOneRect, Color.White);
                }

            }
            else if (screen == Screen.outro)
            {
                _spriteBatch.Draw(outroBg, window, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
