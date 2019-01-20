DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

GRANT ALL ON SCHEMA public to postgres;
GRANT ALL ON SCHEMA public to public;



DROP TABLE IF EXISTS bids CASCADE;
DROP TABLE IF EXISTS category CASCADE;
DROP TABLE IF EXISTS condition CASCADE;
DROP TABLE IF EXISTS item CASCADE;
DROP TABLE IF EXISTS ratings CASCADE;
DROP TABLE IF EXISTS users CASCADE;
DROP VIEW IF EXISTS category_report CASCADE;

