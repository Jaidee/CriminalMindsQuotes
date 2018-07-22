using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CriminalMindsQuotes.Data
{
    public class TodayQuotesData
    {
        public async Task<IEnumerable<TodayQuote>> LoadAsync()
        {
            EpisodeData epsiodeData = new EpisodeData();
            List<TodayQuote> todayQuotes = new List<TodayQuote>();
            IList<Episode> episodes = new ObservableCollection<Episode>();
            int dummy = 0;
            dummy++;
            bool quote_found = false;

            var episodeCollection = await epsiodeData.LoadAllAsync();
            foreach(Episode episode in episodeCollection)
            {
                episodes.Add(episode);    
            }

            while (!quote_found)
            {
                Random ran = new Random();
                int record = ran.Next(1, (int)episodes.Count);

                if (episodes[record].Quote_01 == null || episodes[record].Quote_02 == string.Empty)
                    quote_found = false;
                else
                {
                    var item = new TodayQuote();
                    item.Quote = episodes[record].Quote_01;
                    item.Author = episodes[record].Quote_01_Author;
                    item.QuotedBy = episodes[record].Quote_01_By;
                    item.QuoteSeason = episodes[record].EpisodeId.Substring(1, 2);
                    item.QuoteEpisode = episodes[record].EpisodeId.Substring(4, 2);
                    todayQuotes.Add(item);
                    quote_found = true;
                }
                if (episodes[record].Quote_02 == null || episodes[record].Quote_02 == string.Empty)
                    dummy = 1;
                else
                {
                    var item = new TodayQuote();
                    item.Quote = episodes[record].Quote_02;
                    item.Author = episodes[record].Quote_02_Author;
                    item.QuotedBy = episodes[record].Quote_02_By;
                    item.QuoteSeason = episodes[record].EpisodeId.Substring(1, 2);
                    item.QuoteEpisode = episodes[record].EpisodeId.Substring(4, 2);
                    todayQuotes.Add(item);
                }
            }
            return todayQuotes;
        }

    }
}
