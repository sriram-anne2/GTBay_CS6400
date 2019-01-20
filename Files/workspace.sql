http://sqlfiddle.com/#!18/346d8/2

LOGIN - >select password from Users where user_name = 'sanne31';

REGISTER - > INSERT INTO Users (first_name, last_name, user_name, password) VALUES ('Dumb', 'Dumber', 'dummy', 'iamdummy');

LISTING ITEMS - >INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now)
  VALUES (3, 'iPad Pro', 'This is an iPad Pro', 3, 1, 1, 600.00, 650.00, 3, 1299.99);

SEARCHING SPECIFICAL ITEMS
-----------------------------

SELECT   
  A.id as "ID", A.item_name as "Item Name", A.bid_amount as "Current Bid", A.user_name as "High Bidder", A.get_it_now as "Get it Now Price", A.end_time as "Auction Ends"



SEARCHING ALL ITEMS
-----------------------
SELECT 
  A.id as "ID", A.item_name as "Item Name", A.bid_amount as "Current Bid", A.user_name as "High Bidder", A.get_it_now as "Get it Now Price", A.end_time as "Auction Ends"
FROM
(
  Select Item.id, Item.item_name, Bid.bid_amount, Users.user_name, Item.get_it_now, (SELECT DATEADD(day, Item.auction_length, Item.list_time))AS end_time,
  ROW_NUMBER() OVER (PARTITION BY Item.id ORDER BY Bid.bid_amount DESC) ROW_NUM
  FROM Item
  LEFT JOIN Bid on Item.id = Bid.item_id
  LEFT JOIN Users on Bid.bidder_id = Users.id
) A
WHERE ROW_NUM = 1

 
****************************ALL FOR SEARCHING ALL ITEMS***********************************
--------------------
Select id, item_name, get_it_now,
(select Top 1 bid_amount from Bid order by bid_amount where item_id = Item.id) as Current_Bid
from Item;



(Select dateadd(day, auction_length, list_time)) as Auction_Ends;


(select Top 1 bid_amount from Bid order by bid_amount DESC) as Current_Bid;
(Select Top 1 bidder_id from Bid order by bid_amount DESC where item_id = Item.id) as High_bidder, 

select item_id, max(bid_amount) from Bid Group By item_id; 
---------------------------------------------------------------
Select Item.id, Item.item_name, Bid.bid_amount as "Current Bid", Bid.bidder_id as "Highest Bidder"
From Item
Left Join Bid On Item.id = Bid.item_id
WHERE Bid.bid_amount in (Select Max(bid_amount) from Bid);


Group By Item.id, Item.item_name, Bid.bidder_id
, Bid.bid_amount


LEFT JOIN
(
  Select Users.id, Users.user_name, Bid.bidder_id
  From Users
  Left Join Bid on Users.id = Bid.bidder_id
) B


---------------------------------------------------------------
Select Item.id, Item.item_name, 
(Select Top 1 Bid.bid_amount order by Bid.bid_amount)as "Current Bid", 
Bid.bidder_id as "Bidder"
From Item
Left Join Bid On Item.id = Bid.item_id
Order By Item.id;

----------------------------------------------------------
SELECT 
  A.item_name, A.bid_amount
FROM 
    (
      Select Item.item_name, Bid.bid_amount, 
      ROW_NUMBER() OVER(PARTITION BY Item.id ORDER BY Bid.bid_amount) AS RN
      from Item
      left join Bid on Item.id = Bid.item_id
    ) A
WHERE A.RN = 1;

*********************************************************

ITEM DESCRIPTION 
----------------
Select Item.item_name, Item.description, 
ItemCategory.category_name, 
ItemCondition.condition_name, 
Item.returnable, Item.get_it_now, 
DATEADD(day, Item.auction_length, Item.list_time)AS "Auction Ends"
From
Item LEFT JOIN ItemCategory on Item.category_id = ItemCategory.id
LEFT JOIN ItemCondition on Item.condition_id = ItemCondition.id
Where Item.id = 2
****SEEING TOP 4 Bids for Item ID******

Select TOP 4 Bid.bid_amount, Bid.bid_time, Users.user_name
From Bid
Left Join Users On Bid.bidder_id = Users.id
Left Join Item On Bid.item_id = Item.id
Where Item.id = 2
Order By bid_amount DESC

****Placing a Bid*****

INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (6, 750, 4);


********************************************************
EDIT DESCRIPTION
----------------------
Update Item
Set description = 'beautiful painting by Van Gogh'
where id = 6 AND user_id = 1;


*********************************************************
VIEWING THE RATINGS
--------------------
Select Item.item_name as "Item Name", 
AVG(Rating.rating) as "Average Rating", 
Users.id, 
Rating.rating,
Rating.comment
From Rating
Left Join Item on Rating.item_id = Item.id
Left Join Users on Rating.rater_id = Users.id
where Rating.item_id = 5
Group By Item.item_name, Users.id, Rating.rating, Rating.comment

