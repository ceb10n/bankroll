using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using bankroll.service.services.interfaces;
using System;
using System.Collections.Generic;

namespace bankroll.service.services
{
    public class EntryService : Service<Entry>, IEntryService
    {
        private readonly IEntryRepository _repository;
        private readonly IPlayerService _playerService;

        public EntryService(IEntryRepository repository, IPlayerService playerService) : base(repository)
        {
            _repository = repository;
            _playerService = playerService;
        }

        public IList<Entry> EntriesFromPlayer(Player player, DateTime? since = null)
        {
            return _repository.EntriesFromPlayer(player, since);
        }

        public override void Edit(Entry item, Guid id)
        {
            var oldEntry = FindById(item.Id);
            var player = _playerService.FindById(oldEntry.PlayerId.Value);

            if (player != null)
            {
                player.Bankroll = player.Bankroll + oldEntry.BuyIn;
                player.Bankroll = player.Bankroll - oldEntry.CashOut ?? 0m;
            }

            player.AddEntryToBankroll(item);

            _playerService.EditBankroll(player);
            
            base.Edit(item, item.Id);
        }

        public override void Add(Entry item)
        {
            item.Id = Guid.NewGuid();

            if (item.Date == DateTime.MinValue)
                item.Date = DateTime.Now;

            base.Add(item);

            var player = _playerService.FindById(item.PlayerId.Value);
            player.AddEntryToBankroll(item);

            _playerService.EditBankroll(player);
        }
    }
}
