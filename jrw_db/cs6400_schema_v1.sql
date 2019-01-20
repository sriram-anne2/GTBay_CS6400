CREATE TABLE Category (
  id SERIAL PRIMARY KEY NOT NULL,
  category_name VARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO Category (category_name) VALUES ('Art');
INSERT INTO Category (category_name) VALUES ('Books');
INSERT INTO Category (category_name) VALUES ('Electronics');
INSERT INTO Category (category_name) VALUES ('Home & Garden');
INSERT INTO Category (category_name) VALUES ('Sporting Goods');
INSERT INTO Category (category_name) VALUES ('Toys');
INSERT INTO Category (category_name) VALUES ('Other');

CREATE TABLE Condition (
  id SERIAL PRIMARY KEY NOT NULL,
  condition_name VARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO Condition (condition_name) VALUES ('New');
INSERT INTO Condition (condition_name) VALUES ('Very Good');
INSERT INTO Condition (condition_name) VALUES ('Good');
INSERT INTO Condition (condition_name) VALUES ('Fair');
INSERT INTO Condition (condition_name) VALUES ('Poor');

CREATE TABLE Users (
  id SERIAL PRIMARY KEY NOT NULL,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  user_name VARCHAR(50) NOT NULL UNIQUE,
  password VARCHAR(50) NOT NULL,
  isAdmin BOOLEAN NOT NULL DEFAULT FALSE,
  position VARCHAR(50)
);

ALTER TABLE Users
	ADD CONSTRAINT chk_postion_not_null_if_admin
	CHECK ( (NOT isAdmin) OR (position IS NOT NULL));

INSERT INTO Users (first_name, last_name, user_name, password, isAdmin, position) VALUES ('admin', 'admin', 'test_admin', 'test_admin', TRUE, 'System Administrator');
INSERT INTO Users (first_name, last_name, user_name, password, isAdmin) VALUES ('Joshua', 'Webster', 'jwebster34', 'password', FALSE);
INSERT INTO Users (first_name, last_name, user_name, password, isAdmin) VALUES ('Rick', 'Bingen', 'rbingen3', 'password', FALSE);
INSERT INTO Users (first_name, last_name, user_name, password, isAdmin) VALUES ('Sriram', 'Anne', 'sanne31', 'password', FALSE);
INSERT INTO Users (first_name, last_name, user_name, password, isAdmin) VALUES ('Gurdane', 'Sethi', 'gsethi7', 'password', FALSE);

CREATE TABLE Item (
  id SERIAL PRIMARY KEY NOT NULL,
  user_id INT NOT NULL REFERENCES Users(id),
  item_name VARCHAR(50) NOT NULL,
  description TEXT NOT NULL,
  category_id INTEGER NOT NULL REFERENCES Category(id),
  condition_id INTEGER NOT NULL REFERENCES Condition(id),
  returnable BOOLEAN NOT NULL DEFAULT FALSE,
  start_bid NUMERIC (10, 2) NOT NULL,
  min_sale_price NUMERIC (10, 2) NOT NULL DEFAULT 0.0,
  auction_length INTEGER NOT NULL,
  get_it_now NUMERIC (10, 2) NOT NULL,
  winning_bid_id INTEGER,
  list_time TIMESTAMP WITH TIME ZONE DEFAULT (current_timestamp AT TIME ZONE 'UTC'),
  CONSTRAINT chk_auction_length CHECK (auction_length IN (1, 3, 5, 7)),
  CONSTRAINT chk_min_sale_price_not_negative CHECK (min_sale_price > 0),
  CONSTRAINT chk_get_it_now_not_negative CHECK (get_it_now > 0),
  CONSTRAINT chk_start_bid_not_negative CHECK (start_bid > 0),
  CONSTRAINT chk_min_sale_price_greater_equal_start_bid CHECK (min_sale_price >= start_bid)
);

CREATE TABLE Bids (
  id SERIAL PRIMARY KEY NOT NULL,
  bidder_id INT NOT NULL REFERENCES Users(id),
  bid_amount NUMERIC (10, 2) NOT NULL,
  item_id INT NOT NULL REFERENCES Item(id)
);

CREATE TABLE Ratings (
  id SERIAL PRIMARY KEY NOT NULL,
  rater_id INT NOT NULL REFERENCES Users(id),
  item_id INT NOT NULL REFERENCES Item(id),
  rating INT NOT NULL,
  comments TEXT
);

ALTER TABLE Item
	ADD CONSTRAINT item_winning_bid_id_fkey
	FOREIGN KEY (winning_bid_id)
	REFERENCES users(id);

INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now) VALUES (2, 'Apple Mouse', 'This is an Apple Mouse', 3, 1, TRUE, 45.00, 55.00, 3, 99.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now) VALUES (2, 'Apple Pencil', 'This is an Apple Pencil', 3, 1, TRUE, 90.00, 91.00, 7, 109.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now) VALUES (2, 'iPad Pro', 'This is an iPad Pro', 3, 1, TRUE, 600.00, 650.00, 3, 1299.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now) VALUES (2, 'Weight Bench', 'This is a weight bench with 300 lbs. of weight', 5, 3, TRUE, 100.00, 100.00, 5, 250.99);
INSERT INTO Item (user_id, item_name, description, category_id, condition_id, returnable, start_bid, min_sale_price, auction_length, get_it_now) VALUES (2, 'Painting', 'This is a painting', 1, 2, FALSE, 999.00, 999.00, 7, 1999.99);

CREATE VIEW CATEGORY_REPORT AS (
select c.category_name,
	   COUNT(i.id) as Total,
	   MIN(i.get_it_now) as min_price,
	   MAX(i.get_it_now) as max_price,
	   ROUND(AVG(i.get_it_now), 2) as avg_price
from item i
inner join category c ON i.category_id = c.id
GROUP BY category_name
);

