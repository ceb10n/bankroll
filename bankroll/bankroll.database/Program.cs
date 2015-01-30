using bankroll.domain.context;
using bankroll.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.database
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BankrollContext();
            context.Database.Delete();
            context.Database.CreateIfNotExists();

            #region Countries
            var brazil = new Country
            {
                Iso = "BR",
                Iso3 = "BRA",
                Name = "Brazil"
            };

            context.Country.Add(brazil);

            var usa = new Country
            {
                Iso = "US",
                Iso3 = "USA",
                Name = "United States of America"
            };

            context.Country.Add(usa);

            context.SaveChanges();
            #endregion

            #region States
            var saopaulo = new State
            {
                Id = Guid.NewGuid(),
                CountryIso = "BR",
                Name = "São Paulo",
                UF = "SP"
            };

            context.State.Add(saopaulo);

            var parana = new State
            {
                Id = Guid.NewGuid(),
                CountryIso = "BR",
                Name = "Paraná",
                UF = "PR"
            };

            context.State.Add(parana);

            context.SaveChanges();
            #endregion

            #region Cities
            var saopaulocity = new City
            {
                Id = Guid.NewGuid(),
                Name = "São Paulo",
                State = saopaulo
            };

            context.City.Add(saopaulocity);

            var ribeiraopreto = new City
            {
                Id = Guid.NewGuid(),
                Name = "Ribeirão Preto",
                State = saopaulo
            };

            context.City.Add(ribeiraopreto);

            var americana = new City
            {
                Id = Guid.NewGuid(),
                Name = "Americana",
                State = saopaulo
            };

            context.City.Add(americana);

            var atibaia = new City
            {
                Id = Guid.NewGuid(),
                Name = "Atibaia",
                State = saopaulo
            };

            context.City.Add(americana);

            var santos = new City
            {
                Id = Guid.NewGuid(),
                Name = "Santos",
                State = saopaulo
            };

            context.City.Add(santos);

            var guarulhos = new City
            {
                Id = Guid.NewGuid(),
                Name = "Guarulhos",
                State = saopaulo
            };

            context.City.Add(guarulhos);

            var campinas = new City
            {
                Id = Guid.NewGuid(),
                Name = "Campinas",
                State = saopaulo
            };

            context.City.Add(campinas);

            var curitiba = new City
            {
                Id = Guid.NewGuid(),
                Name = "Curitiba",
                State = parana
            };

            context.City.Add(curitiba);

            context.SaveChanges();
            #endregion

            #region PokerSites
            var pokerstars = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "PokerStars",
                Site = "http://www.pokerstars.com/"
            };

            context.PokerSite.Add(pokerstars);

            var poker888 = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "888Poker",
                Site = "http://888poker.com"
            };

            context.PokerSite.Add(poker888);

            var americasCardroom = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "Americas Cardroom",
                Site = "http://www.americascardroom.eu/"
            };

            context.PokerSite.Add(americasCardroom);

            var betonline = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "Bet Online",
                Site = "http://www.betonline.com"
            };

            context.PokerSite.Add(betonline);

            var titanbet = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "Titanbet",
                Site = "http://www.titanbet.com/"
            };

            context.PokerSite.Add(titanbet);

            var bet365 = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "Bet365",
                Site = "http://www.bet365.com"
            };

            context.PokerSite.Add(bet365);

            var williamhill = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "William Hill",
                Site = "http://poker.williamhill.com"
            };

            context.PokerSite.Add(williamhill);

            var carbonpoker = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "Carbon Poker",
                Site = "http://www.carbonpoker.ag"
            };

            context.PokerSite.Add(carbonpoker);

            var lockpoker = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "Lock Poker",
                Site = "http://lockpoker.eu"
            };

            context.PokerSite.Add(lockpoker);

            var fulltilt = new PokerSite
            {
                Id = Guid.NewGuid(),
                Name = "FullTilt",
                Site = "http://www.fulltilt.com"
            };

            context.PokerSite.Add(fulltilt);

            context.SaveChanges();
            #endregion

            #region PokerClubs
            var h2sp = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "H2 Club",
                Phone = "1130785884",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = saopaulocity,
                    District = "Pinheiros",
                    Number = "170",
                    Street = "Rua Henrique Schaumann",
                    ZipCode = "05413010"
                }
            };

            context.PokerClub.Add(h2sp);

            var vegasholdemclub = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Vegas Holdem Club",
                Phone = "1138847558",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = saopaulocity,
                    District = "Itaim",
                    Number = "312",
                    Street = "Rua Bento de Andrade",
                    ZipCode = "04503000"
                }
            };

            context.PokerClub.Add(vegasholdemclub);

            var starsclub = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Stars Club",
                Phone = "1134770581",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = saopaulocity,
                    District = "Itaim",
                    Number = "896",
                    Street = "Rua Clodomiro Amazonas",
                    ZipCode = "04537-002"
                }
            };

            context.PokerClub.Add(starsclub);

            var ligaCuritibana = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Liga Curitibana",
                Phone = "4130272655",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = curitiba,
                    District = "Mirante",
                    Number = "180",
                    Street = "Rua Prof. Lycio Grein de Castro Veloso",
                    ZipCode = "80710-650"
                }
            };

            context.PokerClub.Add(ligaCuritibana);

            var h2ribeiraopreto  = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "H2 Club Ribeirão Preto",
                Phone = "1638771990",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = ribeiraopreto,
                    District = "Jardim Sumaré",
                    Number = "1139",
                    Street = "Rua Altino Arantes",
                    ZipCode = "14025-030"
                }
            };

            context.PokerClub.Add(h2ribeiraopreto);

            var clubeMonteCarlo = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Clube Monte Carlo",
                Phone = "1936457815",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = americana,
                    District = "Centro",
                    Number = "551",
                    Street = "Rua 12 de Novembro",
                    ZipCode = "13465-490"
                }
            };

            context.PokerClub.Add(clubeMonteCarlo);

            var saporePokerClub = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Sapore Poker Club",
                Phone = "1128924277",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = saopaulocity,
                    District = "Tatuapé",
                    Number = "240",
                    Street = "Rua Santa Virginia",
                    ZipCode = "03084-000"
                }
            };

            context.PokerClub.Add(saporePokerClub);

            var thwOwlsClub = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "The Owls Club",
                Phone = "1123065481",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = saopaulocity,
                    District = "Ipiranga",
                    Number = "178",
                    Street = "Rua Padre Serrão",
                    ZipCode = "04265-050"
                }
            };

            context.PokerClub.Add(thwOwlsClub);

            var millionPokerClub = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Million Poker Club",
                Phone = "1122368468",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = saopaulocity,
                    District = "Imirim",
                    Number = "4110",
                    Street = "Avenida Engenheiro Caetano Álvares",
                    ZipCode = "02413-000"
                }
            };

            context.PokerClub.Add(millionPokerClub);

            var clubDoPokerAtibaia = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Clube do Poker Atibaia",
                Phone = "11947479097",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = atibaia,
                    District = "Jardim Paulista",
                    Number = "3339 F",
                    Street = "Avenida Lucas Nogueira Garcez",
                    ZipCode = "12947-000"
                }
            };

            context.PokerClub.Add(clubDoPokerAtibaia);

            var gralAtibaia = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Gral Atibaia",
                Phone = "11947383954",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = atibaia,
                    District = "Alvinópolis",
                    Number = "964",
                    Street = "Avenida Dona Gertrudes",
                    ZipCode = "12942-540"
                }
            };

            context.PokerClub.Add(gralAtibaia);

            var winPokerSantos = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Win Poker Santos",
                Phone = "1333018719",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = santos,
                    District = "Vila Mathias",
                    Number = "197",
                    Street = "Rua Julio Conceição",
                    ZipCode = "11015-540"
                }
            };

            context.PokerClub.Add(winPokerSantos);

            var spClubSportesDaMente = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "SP Clube Esportes da Mente",
                Phone = "1129374977",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = guarulhos,
                    District = "Guarulhos",
                    Number = "239",
                    Street = "Rua Tapajós",
                    ZipCode = "07111-340"
                }
            };

            context.PokerClub.Add(spClubSportesDaMente);

            var mandalaClub = new PokerClub
            {
                Id = Guid.NewGuid(),
                Name = "Mandala Club",
                Phone = "1933688599",
                Adress = new Adress
                {
                    Id = Guid.NewGuid(),
                    City = campinas,
                    District = "Jardim Paraiso",
                    Number = "400",
                    Street = "R. Dr. Manoel Affonso Ferreira",
                    ZipCode = "13058-427"
                }
            };

            context.PokerClub.Add(spClubSportesDaMente);

            context.SaveChanges();
            #endregion

            #region Tournament Types
            var sng = new TournamentType
            {
                Id = Guid.NewGuid(),
                Name = "Sit n' Go"
            };

            context.TournamentType.Add(sng);


            var spingo = new TournamentType
            {
                Id = Guid.NewGuid(),
                Name = "Spin n' Go"
            };

            context.TournamentType.Add(spingo);


            var mtt = new TournamentType
            {
                Id = Guid.NewGuid(),
                Name = "MTT"
            };

            context.TournamentType.Add(mtt);

            var cash = new TournamentType
            {
                Id = Guid.NewGuid(),
                Name = "Cash"
            };

            context.TournamentType.Add(cash);

            context.SaveChanges();
            #endregion

            #region PokerSite Tournaments
            var pssundaymillion = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Million",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundaymillion);

            var pssundaywarmup = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Warm-Up",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundaywarmup);

            var pssundaystorm = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Storm",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundaystorm);

            var pssundayspark = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Spark",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundayspark);

            var pssundaykickoff = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Kickoff",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundaykickoff);

            var pssundayrebuy = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Rebuy",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundayrebuy);

            var pssundaynl08 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday NLO8",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundaynl08);

            var pssunday500 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday 500",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssunday500);

            var pssundayplo = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday PLO",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundayplo);

            var pssunday2chance = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Second Chance",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssunday2chance);

            var pssunday6max = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday 6-Max",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssunday6max);

            var pssundaysupersonic = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Supersonic",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(pssundaysupersonic);

            var psthehot750 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $7.50",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot750);

            var psthehot44 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $44",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot44);

            var psthehot550 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $5.50",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot550);

            var psthehot22 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $22",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot22);

            var psthehot109 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $109",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot109);

            var psthehot220 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $2.20",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot220);

            var psthehot330 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $3.30",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot330);

            var psthehot440 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $4.40",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot440);

            var psthehot110 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $1.10",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot110);

            var psthehot33 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $33",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot33);

            var psthehot11 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $11",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot11);

            var psthehot1650 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $16.50",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot1650);

            var psthehot75 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $75",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot75);

            var psthehot55 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $55",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot55);

            var psthehot055 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Hot $0.55",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(psthehot055);

            var saturday6max = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday 6-Max",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturday6max);

            var saturdayMicro = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Micro",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdayMicro);

            var saturdayOmaha = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Omaha",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdayOmaha);

            var saturdayEliminator = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Eliminator",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdayEliminator);

            var saturdaySplash = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Splash",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdaySplash);

            var saturdaySuperKO = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Super-Knockout",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdaySuperKO);

            var saturdayCountdown = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Countdown",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdayCountdown);

            var saturdayDuel = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Duel",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdayDuel);

            var saturdaySpeedway = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Saturday Speedway",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(saturdaySpeedway);

            var omania11 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Omania $11 [PLO]",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(omania11);

            var omania27 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Omania $27 [NLO H/L]",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(omania11);

            var omania33 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Omania $33 [PLO]",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(omania33);

            var omania880 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Omania $8.80 [NLO H/L]",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(omania880);

            var omania550 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Omania $5.50 [PLO]",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(omania550);

            var omania1650 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Omania $16.50 [PLO H/L]",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(omania1650);

            var omania22 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Omania $22 [PLO]",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(omania22);

            var thebig330 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $3.30",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig330);

            var thebig1650 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $16.50",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig1650);

            var thebig33 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $33",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig33);

            var thebig44 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $44",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig44);

            var thebig550 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $5.50",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig550);

            var thebig75 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $75",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig75);

            var thebig880 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $8.80",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig880);

            var thebig22 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $22",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig22);

            var thebig109 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $109",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig109);

            var thebig11 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $11",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig11);

            var thebig55 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $55",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig55);

            var thebig162 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $162",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig162);

            var thebig440 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $4.40",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig440);

            var thebig2750 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $27.50",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig2750);

            var thebig220 = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Big $2.20",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(thebig220);

            var sundayBillion = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Sunday Billion",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(sundayBillion);

            var womansSunday = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "Women’s Sunday",
                PokerSite = pokerstars,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(womansSunday);

            var theMegaDeepTournament = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Mega Deep Tournament",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theMegaDeepTournament);

            var the50000MegaDeepTournament = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The $50,000 Turbo Mega Deep",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(the50000MegaDeepTournament);

            var theMegaKnockoutTournament = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Mega Knockout Tournament",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theMegaKnockoutTournament);

            var theMegaDozenTournament = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Mega Dozen Tournament",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theMegaDozenTournament);

            var theMegaMicroTournament = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Mega Micro Tournament",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theMegaMicroTournament);

            var the200000gtdWhale = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The $200,000 GTD Whale",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(the200000gtdWhale);

            var theTyphoon = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series - The Typhoon",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theTyphoon);

            var theTwister = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series – The Twister",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theTwister);

            var theBreeze = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series – The Breeze",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theBreeze);

            var theMonsoon = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series – The Monsoon",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theMonsoon);

            var theLightning = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series – The Lightning - máx. 6",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theLightning);

            var theThunder = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series - The Thunder - máx. 6",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theThunder);

            var theTornado = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series – The Tornado",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theTornado);

            var theHurricane = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series – The Hurricane",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theHurricane);

            var theCyclone = new PokerSiteTournament
            {
                Id = Guid.NewGuid(),
                Name = "The Daily HighRoller Series – The Cyclone",
                PokerSite = poker888,
                TournamentType = mtt
            };

            context.PokerSiteTournament.Add(theCyclone);

            context.SaveChanges();
            #endregion

            context.SaveChanges();
        }
    }
}
