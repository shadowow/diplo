﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using diploma.Models.Accounts;

namespace diploma.Models.Core
{
    public class Client
    {
        public virtual int ID { get; set; }
        public virtual string Phone { get; set; }
        public virtual TeleStation Station { get; set; }
        public virtual Tariff CurrentTariff { get; set; }
        public virtual Address Address { get; set; }
        public virtual bool IsLegalEntity { get; set; }

        public virtual ISet<Debt> Debts { get; set; }
        public virtual ISet<FinishedTariff> TariffsStory { get; set; }
        public virtual ISet<Call> CallsStory { get; set; }

        private User user = null;
        public virtual User User
        {
            get { return user; }
            set { user = value; }
        }

        public Client()
        {
            Debts = new HashSet<Debt>();
            TariffsStory = new HashSet<FinishedTariff>();
            CallsStory = new HashSet<Call>();
        }
    }
}

 public class ClientMap : ClassMap<diploma.Models.Core.Client>
    {
        public ClientMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            Map(x => x.Phone);
            Map(x => x.IsLegalEntity);
            References(x => x.Address).Cascade.All();
            References(x => x.Station).Cascade.All();
            References(x => x.CurrentTariff).Cascade.All();

            HasOne(x => x.User);
            HasMany(x => x.Debts).Inverse();
            HasMany(x => x.TariffsStory).Inverse();
            HasMany(x => x.CallsStory).Inverse();
        }
    }
