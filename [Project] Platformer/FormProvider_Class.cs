using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Project__Platformer
{
    // create one instance of a form
    public class FormProvider
    {
        // 'MainMenu' reference
        public static MainMenu MainMenu_Form
        {
            get
            {
                // if 'mainmenu' form is gone
                if (_mainmenu == null)
                {
                    // create its new instance
                    _mainmenu = new MainMenu();
                }
                // give that form
                return _mainmenu;
            }
        }
        private static MainMenu _mainmenu;

        // 'ChooseGameType' reference
        public static ChooseGameType CGT_Form
        {
            get
            {
                // if 'ChooseGameType' form is gone
                if (_gametype == null)
                {
          
                    // create its new instance
                    _gametype = new ChooseGameType();
                }
                    // give that form
                    return _gametype;
                }
            }

        private static ChooseGameType _gametype;
        
        
        // 'StoryModeLevels' reference
        public static NormalModeLevels SML_Form
        {
            get
            {
                // if 'StoryModeLevels' form is gone
                if (_levels == null)
                {

                    // create its new instance
                    _levels = new NormalModeLevels();
                }
                    // give that form
                    return _levels;
                }
            }
        private static NormalModeLevels _levels;
        
        // 'StoryModeLevels' reference
        public static Bonus_Mode BL_Form
        {
            get
            {
                // if 'StoryModeLevels' form is gone
                if (_Blevels == null)
                {

                    // create its new instance
                    _Blevels = new Bonus_Mode();
                }
                    // give that form
                    return _Blevels;
                }
            }
        private static Bonus_Mode _Blevels;
        
        // 'Settings' reference
        public static Settings SETT_Form
        {
            get
            {
                // if 'Settings' form is gone
                if (_settings == null)
                {

                    // create its new instance
                    _settings = new Settings();
                }
                    // give that form
                    return _settings;
                }
            }
        private static Settings _settings;
        
        // 'Achievements' reference
        public static AchievementsForm Achs_Form
        {
            get
            {
                // if 'Achievements' form is gone
                if (_achs == null)
                {

                    // create its new instance
                    _achs = new AchievementsForm();
                }
                    // give that form
                    return _achs;
                }
            }
        private static AchievementsForm _achs;
        
        // 'The Game' reference
        public static TheGame TheGame_Form
        {
            get
            {
                // if 'TheGame' form is gone
                if (_thegame == null)
                {

                    // create its new instance
                    _thegame = new TheGame();
                }
                // give that form
                return _thegame;
            }
        }
        
        private static TheGame _thegame;
        
        // 'Stats Form' reference
        public static Stats Stats_Form
        {
            get
            {
                // if 'Stats' form is gone
                if (_statform == null)
                {

                    // create its new instance
                    _statform = new Stats();
                }
                    // give that form
                    return _statform;
                }
            }
        private static Stats _statform;

    }
}
