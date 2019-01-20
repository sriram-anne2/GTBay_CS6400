CREATE TABLE ItemCategory (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  category_name VARCHAR(50) NOT NULL UNIQUE
);
INSERT INTO ItemCategory (category_name) VALUES ('Art');
INSERT INTO ItemCategory (category_name) VALUES ('Books');
INSERT INTO ItemCategory (category_name) VALUES ('Electronics');
INSERT INTO ItemCategory (category_name) VALUES ('Home & Garden');
INSERT INTO ItemCategory (category_name) VALUES ('Sporting Goods');
INSERT INTO ItemCategory (category_name) VALUES ('Toys');
INSERT INTO ItemCategory (category_name) VALUES ('Other');

CREATE TABLE ItemCondition (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  condition_name VARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO ItemCondition (condition_name) VALUES ('Poor');
INSERT INTO ItemCondition (condition_name) VALUES ('Fair');
INSERT INTO ItemCondition (condition_name) VALUES ('Good');
INSERT INTO ItemCondition (condition_name) VALUES ('Very Good');
INSERT INTO ItemCondition (condition_name) VALUES ('New');

CREATE TABLE Users (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  user_name VARCHAR(50) NOT NULL UNIQUE,
  password VARCHAR(50) NOT NULL
);

INSERT INTO Users (first_name, last_name, user_name, password) VALUES ('Yi', 'Jiang', 'test_admin', 'test_admin');
INSERT INTO Users (first_name, last_name, user_name, password) VALUES ('Joshua', 'Webster', 'jwebster34', 'password');
INSERT INTO Users (first_name, last_name, user_name, password) VALUES ('Rick', 'Bingen', 'rbingen3', 'password');
INSERT INTO Users (first_name, last_name, user_name, password) VALUES ('Sriram', 'Anne', 'sanne31', 'password');
INSERT INTO Users (first_name, last_name, user_name, password) VALUES ('Gurdane', 'Sethi', 'gsethi7', 'password');
INSERT INTO Users (first_name, last_name, user_name, password) VALUES ('Dumb', 'Dumber', 'dummy', 'iamdummy');

CREATE TABLE AdminUsers (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  user_id INT NOT NULL REFERENCES Users(id),
  position VARCHAR(50) NOT NULL
);

INSERT INTO AdminUsers (user_id, position) VALUES (1, 'sysadmin');
INSERT INTO AdminUsers (user_id, position) VALUES (5, 'big_admin');

CREATE TABLE Item (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  user_id INT NOT NULL REFERENCES Users(id),
  item_name VARCHAR(50) NOT NULL,
  description TEXT NOT NULL,
  category_id INTEGER NOT NULL REFERENCES ItemCategory(id),
  condition_id INTEGER NOT NULL REFERENCES ItemCondition(id),
  returnable BIT NOT NULL DEFAULT 0,
  start_bid NUMERIC (10, 2) NOT NULL,
  min_sale_price NUMERIC (10, 2) NOT NULL DEFAULT 0.0,
  auction_length INTEGER NOT NULL,
  get_it_now NUMERIC (10, 2),
  winning_bid_id INTEGER,
  list_time DATETIME DEFAULT GETDATE() NOT NULL,
  CONSTRAINT chk_auction_length CHECK (auction_length IN (1, 3, 5, 7)),
  CONSTRAINT chk_min_sale_price_not_negative CHECK (min_sale_price > 0),
  CONSTRAINT chk_get_it_now_not_negative CHECK (get_it_now > 0),
  CONSTRAINT chk_start_bid_not_negative CHECK (start_bid > 0),
  CONSTRAINT chk_min_sale_price_greater_equal_start_bid CHECK (min_sale_price >= start_bid)
);

INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now)
  VALUES (5, 'Used Laptop', 'Lightly used Windows 10 machine', 3, 4, 0, 50, 100, 7, 250.5);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now)
  VALUES (2, 'Apple Mouse', 'This is an Apple Mouse', 3, 1, 1, 45.00, 55.00, 3, 99.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now) 
  VALUES (2, 'Apple Pen', 'This is an Apple Pencil', 3, 1, 1, 90.00, 91.00, 7, 109.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now)
  VALUES (3, 'iPad Pro', 'This is an iPad Pro', 3, 1, 1, 600.00, 650.00, 3, 1299.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now) 
  VALUES (2, 'Weight Bench', 'This is a weight bench with 300 lbs. of weight', 5, 3, 1, 100.00, 100.00, 5, 250.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length) 
  VALUES (1, 'Painting', 'This is a painting', 1, 2, 0, 999.00, 999.00, 7);

CREATE TABLE Bid (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  bidder_id INT NOT NULL REFERENCES Users(id),
  bid_amount NUMERIC (10, 2) NOT NULL,
  item_id INT NOT NULL REFERENCES Item(id),
  bid_time DATETIME DEFAULT GETDATE() NOT NULL
);

INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (4, 55, 2);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (5, 70, 2);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (4, 80, 2);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (2, 95, 3);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (3, 110, 1);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (1, 100, 3);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (2, 105, 5);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (3, 125, 5);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (2, 1005, 6);
INSERT INTO Bid (bidder_id, bid_amount, item_id) VALUES (5, 650, 4);



CREATE TABLE Rating (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  rater_id INT NOT NULL REFERENCES Users(id),
  item_id INT NOT NULL REFERENCES Item(id),
  rating INT NOT NULL,
  comment VARCHAR(150),
  rating_time DATETIME DEFAULT GETDATE() NOT NULL,
  CONSTRAINT chk_rating CHECK (rating IN (0, 1, 2, 3, 4, 5))
);

INSERT INTO Rating (rater_id, item_id, rating, comment) VALUES (2, 5, 3, 'Tubular item');

ALTER TABLE Item
ADD FOREIGN KEY (winning_bid_id) REFERENCES Bid(id);