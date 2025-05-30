using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Core;

namespace AdvancedTeamBalance
{
    public class PluginConfig : BasePluginConfig
    {
        public GeneralSettings General { get; set; } = new GeneralSettings();
        public TeamSwitchSettings TeamSwitch { get; set; } = new TeamSwitchSettings();
        public BalancingSettings Balancing { get; set; } = new BalancingSettings();
        public MessageSettings Messages { get; set; } = new MessageSettings();
        public AdminSettings Admin { get; set; } = new AdminSettings();
    }
    
    /// <summary>
    /// General plugin settings
    /// </summary>
    public class GeneralSettings
    {
        /// <summary>
        /// Tag shown in chat messages
        /// </summary>
        public string PluginTag { get; set; } = $"{ChatColors.Red}[TeamBalance]{ChatColors.Default}";
        
        /// <summary>
        /// Minimum number of players required for balancing to activate
        /// </summary>
        public int MinimumPlayers { get; set; } = 6;
        
        /// <summary>
        /// Enable verbose logging for troubleshooting
        /// </summary>
        public bool EnableDebug { get; set; } = false;
    }
    
    /// <summary>
    /// Settings for switching players between teams
    /// </summary>
    public class TeamSwitchSettings
    {
        /// <summary>
        /// Events that trigger team balancing
        /// Options: OnRoundStart, OnRoundEnd, OnPlayerJoin, OnPlayerDisconnect, OnFreezeTimeEnd
        /// </summary>
        public List<string> BalanceTriggers { get; set; } = [ 
            "OnRoundStart", 
            "OnPlayerJoin"
        ];
        
        /// <summary>
        /// Maximum allowed difference in team sizes (highest priority rule)
        /// If set to 1, teams will be balanced such that one team cannot have more than one extra player
        /// </summary>
        public int MaxTeamSizeDifference { get; set; } = 1;
        
        /// <summary>
        /// Minimum rounds a player must stay on their team before being eligible for switch
        /// </summary>
        public int MinRoundsBeforeSwitch { get; set; } = 2;
        
        /// <summary>
        /// Seconds of immunity after being switched to prevent ping-ponging
        /// </summary>
        public int SwitchImmunityTime { get; set; } = 60;
        
        /// <summary>
        /// Whether to balance teams during warmup rounds
        /// </summary>
        public bool BalanceDuringWarmup { get; set; } = false;
    }
    
    public class BalancingSettings
    {
        /// <summary>
        /// How to balance teams
        /// Options: 
        /// - "KD": Balance based on kill/death ratio
        /// - "KDA": Balance based on kill/death/assist ratio (includes assists)
        /// - "Score": Balance based on in-game score
        /// - "WinRate": Balance based on round win percentage
        /// - "ScrambleRandom": Completely randomize teams
        /// - "ScrambleSkill": Distribute players evenly by skill
        /// </summary>
        public string BalanceMode { get; set; } = "KDA";
        
        /// <summary>
        /// How large a skill difference must be to trigger balancing (percentage)
        /// Lower values trigger more frequent balancing
        /// </summary>
        public double SkillDifferenceThreshold { get; set; } = 20.0;
        
        /// <summary>
        /// Whether to reset player statistics after a scramble
        /// </summary>
        public bool ResetStatsAfterScramble { get; set; } = true;
        
        /// <summary>
        /// Number of consecutive rounds one team must win to trigger auto-scramble
        /// Set to 0 to disable auto-scramble
        /// </summary>
        public int AutoScrambleAfterWinStreak { get; set; } = 5;
        
        /// <summary>
        /// Number of consecutive rounds one team must lose to trigger skill boosting
        /// Set to 0 to disable boosting
        /// </summary>
        public int BoostAfterLoseStreak { get; set; } = 5;
        
        /// <summary>
        /// Percentage to boost the losing team's skill threshold by when balancing
        /// Higher values give the losing team higher skilled players when balancing
        /// </summary>
        public int BoostPercentage { get; set; } = 20;
    }
    
    /// <summary>
    /// Settings for plugin messages and notifications
    /// </summary>
    public class MessageSettings
    {
        /// <summary>
        /// Whether to announce team balancing events in chat
        /// </summary>
        public bool AnnounceBalancing { get; set; } = true;
        
        /// <summary>
        /// Whether to send private messages to players who are switched
        /// </summary>
        public bool NotifySwitchedPlayers { get; set; } = true;
        
        /// <summary>
        /// Whether to explain the reason for the balance (which metric caused the switch)
        /// </summary>
        public bool ExplainBalanceReason { get; set; } = true;
    }
    
    /// <summary>
    /// Settings for admin privileges
    /// </summary>
    public class AdminSettings
    {
        /// <summary>
        /// Whether to exclude admins from automatic team switches
        /// </summary>
        public bool ExcludeAdmins { get; set; } = true;
        
        /// <summary>
        /// Admin flag that grants exemption from team switching
        /// </summary>
        public string AdminExemptFlag { get; set; } = "@css/ban";
    }
}
