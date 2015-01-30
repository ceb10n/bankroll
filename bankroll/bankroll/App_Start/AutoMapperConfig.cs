using AutoMapper;
using bankroll.domain.entities;
using bankroll.Models;
using System;

namespace bankroll
{
    public static class AutoMapperConfig
    {
        public static void CreateAutoMapperMappings()
        {
            AutoMapper.Mapper.CreateMap<Account, LoginModel>()
               .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            AutoMapper.Mapper.CreateMap<LoginModel, Account>()
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Login))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            AutoMapper.Mapper.CreateMap<Account, RegisterModel>()
               .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            AutoMapper.Mapper.CreateMap<RegisterModel, Account>()
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Login))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            AutoMapper.Mapper.CreateMap<Player, RegisterModel>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            AutoMapper.Mapper.CreateMap<RegisterModel, Player>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            AutoMapper.Mapper.CreateMap<EditBankrollModel, Player>()
               .ForMember(dest => dest.Bankroll, opt => opt.MapFrom(src => src.Bankroll));

            AutoMapper.Mapper.CreateMap<NewEntry, Entry>().ConvertUsing(new NewEntryToEntryConverter());
            AutoMapper.Mapper.CreateMap<EditEntry, Entry>().ConvertUsing(new EditEntryToEntryConverter());
            AutoMapper.Mapper.CreateMap<Entry, EditEntry>().ConvertUsing(new EntryToEditEntryConverter());
        }
    }

    public class EntryToEditEntryConverter : ITypeConverter<Entry, EditEntry>
    {
        public EditEntry Convert(ResolutionContext context)
        {
            var newentry = (Entry)context.SourceValue;
            var entry = new EditEntry
            {
                CashOut = newentry.CashOut.HasValue ? newentry.CashOut.Value : 0m,
                BuyIn = newentry.BuyIn,
                Online = newentry.Online.HasValue ? newentry.Online.Value : false,
                Date = newentry.Date,
                Id = newentry.Id,
                PlayerId = newentry.PlayerId.HasValue ? newentry.PlayerId.Value : Guid.Empty
            };

            if (newentry.PokerClubId.HasValue)
                entry.PokerPlaceId = newentry.PokerClubId.Value;
            else if (newentry.PokerSiteId.HasValue)
                entry.PokerPlaceId = newentry.PokerSiteId.Value;
            
            return entry;
        }
    }
    public class EditEntryToEntryConverter : ITypeConverter<EditEntry, Entry>
    {
        public Entry Convert(ResolutionContext context)
        {
            var newentry = (EditEntry)context.SourceValue;
            var entry = new Entry
            {
                CashOut = newentry.CashOut,
                BuyIn = newentry.BuyIn,
                Online = newentry.Online,
                Date = newentry.Date,
                PlayerId = newentry.PlayerId,
                Id = newentry.Id
            };

            if (newentry.PokerPlaceId != Guid.Empty)
            {
                if (newentry.Online)
                {
                    entry.PokerSiteId = newentry.PokerPlaceId;
                    entry.SiteTournamentId = newentry.TournamentId;
                }
                else
                {
                    entry.PokerClubId = newentry.PokerPlaceId;
                    entry.ClubTournamentId = newentry.TournamentId;
                }
            }
            return entry;
        }
    }

    public class NewEntryToEntryConverter : ITypeConverter<NewEntry, Entry>
    {
        public Entry Convert(ResolutionContext context)
        {
            var newentry = (NewEntry) context.SourceValue;
            var entry = new Entry
            {
                CashOut = newentry.CashOut,
                BuyIn = newentry.BuyIn,
                Online = newentry.Online,
                Date = newentry.Date,
            };

            if (newentry.PokerPlaceId != Guid.Empty)
            {
                if (newentry.Online)
                {
                    entry.PokerSiteId = newentry.PokerPlaceId;
                    entry.SiteTournamentId = newentry.TournamentId;
                }
                else
                {
                    entry.PokerClubId = newentry.PokerPlaceId;
                    entry.ClubTournamentId = newentry.TournamentId;
                }
            }
            return entry;
        }
    }
}