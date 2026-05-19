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
        bool continueButtonHover = false;
        bool songPlayed = false;

        Texture2D introbg;
        Texture2D newsbg;
        Texture2D hellbg;
        Texture2D beachbg;

        Texture2D snape;
        Rectangle snapeRect;
        Texture2D romeo;
        Rectangle romeoRect;
        Texture2D juliet;
        Rectangle julietRect;
        Texture2D demon;
        Rectangle demonRect;

        Texture2D continueButton;
        Rectangle continueButton_Rect;

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
        Vector2 romeoSpeed;
        Vector2 julietSpeed;
        Vector2 demonSpeed;

        float seconds;

        SpriteFont introText;

        SoundEffect themeMusic;
        SoundEffectInstance themeInstance;

        Color bgColor = Color.DarkViolet;

        MouseState mouseState;
        KeyboardState keyboardState;

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
            sceneOneDialogueOneRect = new Rectangle(270, 150, 200, 200);
            sceneOneDialogueTwoRect = new Rectangle(270, 150, 200, 200);
            sceneOneDialogueThreeRect = new Rectangle(240, 150, 200, 200);
            sceneOneDialogueFourRect = new Rectangle(0, 180, 200, 200);
            sceneOneDialogueFiveRect = new Rectangle(230, 290, 200, 150);

            julietRect = new Rectangle(-230, 230, 230, 230);
            demonRect = new Rectangle(-300, 300, 230, 380);  

            continueButton_Rect = new Rectangle(595, 5, 200, 100);

            snapeSpeed = new Vector2(3, 0);
            julietSpeed = new Vector2(3, 0);
            demonSpeed = new Vector2(0, 3);

            seconds = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introbg = Content.Load<Texture2D>("IntroBackground");
            newsbg = Content.Load<Texture2D>("News");
            hellbg = Content.Load<Texture2D>("Hell");
            beachbg = Content.Load<Texture2D>("Beach");
            romeo = Content.Load<Texture2D>("Romeo");
            juliet = Content.Load<Texture2D>("Juliet");
            snape = Content.Load<Texture2D>("Snape");
            demon = Content.Load<Texture2D>("Demon");
            introText = Content.Load<SpriteFont>("IntroText");
            themeMusic = Content.Load<SoundEffect>("themeMusic");
            themeInstance = themeMusic.CreateInstance();

            continueButton = Content.Load<Texture2D>("continue");

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
                    screen = Screen.snapeInterview;
                }
                else if (themeInstance.State == SoundState.Stopped)
                {
                    screen = Screen.snapeInterview;
                }
            }
            else if (screen == Screen.snapeInterview)
            {
                snapeRect.X += (int)snapeSpeed.X;

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
                    else if (seconds > 16)
                    {
                        continueButtonHover = true; 

                        if (mouseState.LeftButton == ButtonState.Pressed && continueButton_Rect.Contains(mouseState.Position))
                        {
                            seconds = 0;
                            timerStart = false;

                            dialogueOne = false;
                            dialogueTwo = false;
                            dialogueThree = false;
                            dialogueFour = false;
                            dialogueFive = false;

                            continueButtonHover = false;

                            screen = Screen.julietGossipWithDemon;
                        }
                    }
                }
            }
            else if (screen == Screen.julietGossipWithDemon)
            {
                if (julietRect.X >= 500 && demonRect.Y >= 300)
                {
                    julietRect.X = 500;
                    demonRect.Y = 300;

                    julietSpeed.X = 0;
                    demonRect.Y = 0;

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
                    else if (seconds > 16)
                    {
                        continueButtonHover = true;

                        if (mouseState.LeftButton == ButtonState.Pressed && continueButton_Rect.Contains(mouseState.Position))
                        {
                            seconds = 0;
                            timerStart = false;

                            dialogueOne = false;
                            dialogueTwo = false;
                            dialogueThree = false;
                            dialogueFour = false;
                            dialogueFive = false;

                            continueButtonHover = false;

                            screen = Screen.romeosNewGirl;
                        }
                    }
                }

             }
            //else if (screen == Screen.romeosNewGirl)
            //{

            //}
            //else if (screen == Screen.outro)
            //{

            //}

            base.Update(gameTime);
        
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();

            if (screen == Screen.intro)
            {
                _spriteBatch.Draw(introbg, window, Color.White);
                _spriteBatch.DrawString(introText, "Welcome to the play of ", new Vector2(140, 200), Color.Black);
                _spriteBatch.DrawString(introText, "'Interview with Muggles!'", new Vector2(140, 250), Color.Black);
                _spriteBatch.DrawString(introText, "Please press space to \ncontinue!", new Vector2(140, 300), Color.Black);
            }
            else if (screen == Screen.snapeInterview)
            {
                _spriteBatch.Draw(newsbg, window, Color.White);
                _spriteBatch.Draw(snape, snapeRect, Color.White);

                if (dialogueOne)
                {
                    _spriteBatch.Draw(sceneOneDialogueOne, sceneOneDialogueOneRect, Color.White);
                }
                else if (dialogueTwo)
                {
                    _spriteBatch.Draw(sceneOneDialogueTwo, sceneOneDialogueTwoRect, Color.White);
                }
                else if (dialogueThree)
                {
                    _spriteBatch.Draw(sceneOneDialogueThree, sceneOneDialogueThreeRect, Color.White);
                }
                else if (dialogueFour)
                {
                    _spriteBatch.Draw(sceneOneDialogueFour, sceneOneDialogueFourRect, Color.White);
                }
                else if (dialogueFive)
                {
                    _spriteBatch.Draw(sceneOneDialogueFive, sceneOneDialogueFiveRect, Color.White);
                }
                
                if (continueButtonHover)
                {
                    _spriteBatch.Draw(continueButton, continueButton_Rect, Color.White);
                }
            }

            else if (screen == Screen.julietGossipWithDemon)
            {
                _spriteBatch.Draw(hellbg, window, Color.White);
                _spriteBatch.Draw(juliet, julietRect, Color.White);
                _spriteBatch.Draw(demon, demonRect, Color.White);

                //if (dialogueOne)
                //{
                //    _spriteBatch.Draw(sceneOneDialogueOne, sceneOneDialogueOneRect, Color.White);
                //}
                //else if (dialogueTwo)
                //{
                //    _spriteBatch.Draw(sceneOneDialogueTwo, sceneOneDialogueTwoRect, Color.White);
                //}
                //else if (dialogueThree)
                //{
                //    _spriteBatch.Draw(sceneOneDialogueThree, sceneOneDialogueThreeRect, Color.White);
                //}
                //else if (dialogueFour)
                //{
                //    _spriteBatch.Draw(sceneOneDialogueFour, sceneOneDialogueFourRect, Color.White);
                //}
                //else if (dialogueFive)
                //{
                //    _spriteBatch.Draw(sceneOneDialogueFive, sceneOneDialogueFiveRect, Color.White);
                //}
                
            }

                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

//1.Intro / Title Screen

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
