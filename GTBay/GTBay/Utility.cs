using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GTBay
{
    internal class Utility
    {

        internal static string GetConnectionString()
        {
            string returnValue = null;

            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["GTBay.Properties.Settings.connString"];

            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;

        }

        internal static string GetConditionsSql()
        {
            string cmd ="SELECT id, condition_name FROM ItemCondition ORDER BY id";

            return cmd;
        }

        internal static string GetCategoriesSql()
        {
            string cmd = "SELECT id, category_name FROM ItemCategory ORDER BY id";

            return cmd;
        }

        internal static string LoginSql()
        {
            string cmd = "SELECT password, Users.id, position FROM Users LEFT OUTER JOIN AdminUsers ON Users.id = AdminUsers.user_id WHERE user_name = @username";

            return cmd;
        }

        internal static string UserExistsSql()
        {
            string cmd = "SELECT COUNT(1) FROM Users WHERE user_name = @username";

            return cmd;
        }

        internal static string RegisterSql()
        {
            string cmd = "INSERT INTO Users (first_name, last_name, user_name, password) VALUES (@fName,@lName,@username,@password)";

            return cmd;
        }

        internal static string SearchSql()
        {
            string cmd = "SELECT A.id as \"ID\", A.item_name as \"Item Name\", A.bid_amount as \"Current Bid\", " +
                         "A.user_name as \"High Bidder\", A.get_it_now as \"Get it Now Price\", " +
                         "A.end_time as \"Auction Ends\", A.start_bid as \"Start Bid\" " +
                         "FROM " +
                         "(" +
                         "Select Item.id, Item.item_name, Bid.bid_amount, Users.user_name, Item.get_it_now, Item.start_bid, " +
                            "(" +
                            "SELECT DATEADD(day, Item.auction_length, Item.list_time)" +
                            ")" +
                            "AS end_time, ROW_NUMBER() " +
                            "OVER(PARTITION BY Item.id ORDER BY Bid.bid_amount DESC) " +
                            "ROW_NUM " +
                         "FROM " +
                         "Item " +
                         "LEFT JOIN " +
                         "Bid " +
                         "on Item.id = Bid.item_id " +
                         "LEFT JOIN " +
                         "Users " +
                         "on Bid.bidder_id = Users.id " +
                         "where " +
                         "(" +
                            "Item.description like @keyword or Item.item_name like @keyword) " +
                            "and Item.condition_id >= @condition " +
                            "and Item.category_id in " +
//                                "(Select id from ItemCategory where id = @category)" +
                                "(Select id from ItemCategory where category_name like @category)" +
                         ") A " +
                         "WHERE ROW_NUM = 1 " +
                         "and ISNULL(A.bid_amount,A.start_bid) > @minPrice " +
                         "and ISNULL(A.bid_amount,A.start_bid) < @maxPrice " +
                         "ORDER BY A.end_time;";

            return cmd;
        }

        internal static string ListItemSql()
        {
            string cmd = "INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now)" +
                            "VALUES (@userId, @itemName, @description, @category, @condition, @returnable, @startBid, @minSale, @auctionLength, @getItNow); ";

            return cmd;
        }

        internal static string UpdateAuctionsSql()
        {
            string cmd = "UPDATE Item "+
                            "SET "+
                             "Item.winning_bid_id = WinningBid.bid_id "+
                            "FROM Item " +
                             "INNER JOIN " +
                             "( " +
                             "SELECT MaxBid.item_id, Bid.id as bid_id, Bid.bidder_id, MaxBid.highest_bid " +
                             "FROM " +
                             "( " +
                             "SELECT Item.id as item_id, MAX(Bid.bid_amount) as highest_bid " +
                             "FROM Item " +
                             "LEFT OUTER JOIN Bid " +
                             "ON Item.id = Bid.item_id " +
                             "GROUP BY Item.id " +
                             ") MaxBid " +
                             "LEFT OUTER JOIN Bid " +
                             "ON Bid.item_id = MaxBid.item_id AND Bid.bid_amount = MaxBid.highest_bid " +
                             ") WinningBid " +
                             "ON Item.id = WinningBid.item_id " +
                            "WHERE " +
                             "Item.winning_bid_id IS NULL " +
                             "AND DATEADD(day, Item.auction_length, Item.list_time) < GETDATE(); ";

            return cmd;
        }

        internal static string AuctionResultsSql()
        {
            string cmd = "SELECT Item.id, Item.item_name, Bid.bid_amount, Users.user_name, Bid.bid_time "+
                            "FROM Item " +
                             "INNER JOIN Bid " +
                             "ON Item.id = Bid.item_id " +
                             "LEFT OUTER JOIN Users " +
                             "ON Bid.bidder_id = Users.id " +
                            "WHERE Item.winning_bid_id = Bid.id; ";

            return cmd;
        }

        internal static string ItemSql()
        {
            string cmd = "SELECT Item.item_name, Item.description, "+
                             "ItemCategory.category_name, "+
                             "ItemCondition.condition_name, "+
                             "Item.returnable, Item.get_it_now, Item.user_id, "+
                             "DATEADD(day, Item.auction_length, Item.list_time) AS \"Auction Ends\", Item.winning_bid_id , Item.start_bid "+
                            "FROM "+
                             "Item LEFT JOIN ItemCategory ON Item.category_id = ItemCategory.id "+
                             "LEFT JOIN ItemCondition on Item.condition_id = ItemCondition.id "+
                            "WHERE Item.id = @itemId";

            return cmd;
        }

        internal static string UpdateDescriptionSql()
        {
            string cmd = "UPDATE Item "+
                            "SET description = @description "+
                            "WHERE id = @itemId AND user_id = @userId; ";

            return cmd;
        }

        internal static string GetNowSql()
        {
            string cmd = "INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES(@userId, @getItNow, @itemId); ";

            return cmd;
        }

        internal static string GetNow2Sql()
        {
            string cmd = "UPDATE Item SET Item.winning_bid_id = (Select Top 1 id from Bid order by id desc)  WHERE Item.id = @itemId AND Item.winning_bid_id IS NULL; ";

            return cmd;
        }

        internal static string TopBidsSql()
        {
            string cmd = "SELECT TOP 4 Bid.bid_amount, Bid.bid_time, Users.user_name FROM Users INNER JOIN Bid ON Bid.bidder_id = Users.id WHERE Bid.item_id = @itemId ORDER BY Bid.bid_amount DESC; ";

            return cmd;
        }

        internal static string BidSql()
        {
            string cmd = "INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (@userId, @bidAmount, @itemId); ";

            return cmd;
        }

        internal static string categoryReportSql()
        {
            string cmd = "SELECT DISTINCT ItemCategory.category_name, COUNT(Item.get_it_now) as total_items, "+
                             "MIN(Item.get_it_now) as min_price, MAX(Item.get_it_now) as max_price, "+
                             "ROUND(AVG(CAST(Item.get_it_now as FLOAT)),2) as avg_price " +
                            "FROM ItemCategory "+
                             "LEFT OUTER JOIN Item "+
                             "ON ItemCategory.id = Item.category_id "+
                            "GROUP BY ItemCategory.category_name "+
                            "ORDER BY ItemCategory.category_name ASC; ";

            return cmd;
        }

        internal static string userReportSql()
        {
            string cmd = "SELECT A.user_name, A.listed, A.sold, B.purchased, C.rated "+
                            "FROM "+
                             "( "+
                             "SELECT Users.user_name, COUNT(Item.id) as listed, "+
                             "COUNT(Item.winning_bid_id) as sold "+
                             "FROM Users "+
                             "LEFT OUTER JOIN Item "+
                             "ON Users.id = Item.user_id "+
                             "GROUP BY Users.user_name "+
                             ") A "+
                            "LEFT OUTER JOIN "+
                             "( "+
                             "SELECT Users.user_name, COUNT(WinningBids.bid_id) as purchased "+
                             "FROM Users "+
                             "LEFT OUTER JOIN "+
                             "( "+
                             "SELECT Users.user_name, Bid.id as bid_id, Bid.bid_amount "+
                             "FROM Users "+
                             "LEFT OUTER JOIN Bid "+
                             "ON Users.id = Bid.bidder_id "+
                             "INNER JOIN Item "+
                             "On Item.winning_bid_id = Bid.id "+
                             ") WinningBids "+
                             "ON Users.user_name = WinningBids.user_name "+
                             "GROUP BY Users.user_name "+
                             ") B "+
                             "ON A.user_name = B.user_name "+
                            "LEFT OUTER JOIN "+
                             "( "+
                             "SELECT Users.user_name, COUNT(Rating.item_id) as rated "+
                             "FROM Users "+
                             "LEFT OUTER JOIN Rating "+
                             "ON Users.id = Rating.rater_id "+
                             "GROUP BY Users.user_name "+
                             ") C "+
                             "ON A.user_name = C.user_name "+
                            "ORDER BY A.listed DESC; ";

            return cmd;
        }

        internal static string getRatingsSql()
        {
            string cmd = "SELECT Rating.rating, Rating.comment, Rating.rater_id, Users.user_name, Rating.rating_time from Rating INNER JOIN USERS ON Users.id = Rating.rater_id INNER JOIN Item ON Rating.item_id = Item.id where Item.item_name = @itemName ORDER BY Rating.rating_time DESC";

            return cmd;
        }

        internal static string avgRatingSql()
        {
            string cmd = "SELECT AVG(Cast(rating as float)) from Rating INNER JOIN Item ON Rating.item_id = Item.id WHERE Item.item_name = @itemName";

            return cmd;
        }

        internal static string insertRatingSql()
        {
            string cmd = "INSERT INTO Rating (rater_id, item_id, rating, comment, rating_time) VALUES(@userId, @itemId, @rating, @comment, GETDATE())";

            return cmd;
        }

        internal static string deleteRatingSql()
        {
            string cmd = "DELETE FROM Rating WHERE rater_id = @userId AND item_id = @itemId";

            return cmd;
        }


    }
}
