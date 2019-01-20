CREATE TABLE ItemCategory (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  category_name VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE ItemCondition (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  condition_name VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Users (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  user_name VARCHAR(50) NOT NULL UNIQUE,
  password VARCHAR(50) NOT NULL,
  position VARCHAR(50)
);

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
  winning_bid_id INTEGER REFERENCES Bid(id),
  list_time DATETIME DEFAULT GETDATE() NOT NULL,
  CONSTRAINT chk_auction_length CHECK (auction_length IN (1, 3, 5, 7)),
  CONSTRAINT chk_min_sale_price_not_negative CHECK (min_sale_price > 0),
  CONSTRAINT chk_get_it_now_not_negative CHECK (get_it_now > 0),
  CONSTRAINT chk_start_bid_not_negative CHECK (start_bid > 0),
  CONSTRAINT chk_min_sale_price_greater_equal_start_bid CHECK (min_sale_price >= start_bid)
);

CREATE TABLE Bid (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  bidder_id INT NOT NULL REFERENCES Users(id),
  bid_amount NUMERIC (10, 2) NOT NULL,
  item_id INT NOT NULL REFERENCES Item(id),
  bid_time DATETIME DEFAULT GETDATE() NOT NULL
);

CREATE TABLE Rating (
  id INT IDENTITY PRIMARY KEY NOT NULL,
  rater_id INT NOT NULL REFERENCES Users(id),
  item_id INT NOT NULL REFERENCES Item(id),
  rating INT NOT NULL,
  comment VARCHAR(150),
  rating_time DATETIME DEFAULT GETDATE() NOT NULL,
  CONSTRAINT chk_rating CHECK (rating IN (0, 1, 2, 3, 4, 5))
);