﻿using LinqToDB;
using System.Data;
using System.Threading.Tasks;
using KaguyaProjectV2.KaguyaBot.DataStorage.DbData.Models;

namespace KaguyaProjectV2.KaguyaBot.DataStorage.DbData.Context
{
    public partial class KaguyaDb : LinqToDB.Data.DataConnection
    {
        public KaguyaDb() : base("KaguyaContext") { }
        public ITable<AutoAssignedRole> AutoAssignedRoles => GetTable<AutoAssignedRole>();
        public ITable<BlackListedChannel> BlackListedChannels => GetTable<BlackListedChannel>();
        public ITable<CommandHistory> CommandHistories => GetTable<CommandHistory>();
        public ITable<FilteredPhrase> FilteredPhrases => GetTable<FilteredPhrase>();
        public ITable<GambleHistory> GambleHistories => GetTable<GambleHistory>();
        public ITable<MutedUser> MutedUsers => GetTable<MutedUser>();
        public ITable<Server> Servers => GetTable<Server>();
        public ITable<ServerSpecificExp> ServerExp => GetTable<ServerSpecificExp>();
        public ITable<SupporterKey> SupporterKeys => GetTable<SupporterKey>();
        public ITable<TwitchChannel> TwitchChannels => GetTable<TwitchChannel>();
        public ITable<User> Users => GetTable<User>();
        public ITable<WarnAction> WarnActions => GetTable<WarnAction>();
        public ITable<WarnedUser> WarnedUsers => GetTable<WarnedUser>();
    }
}
