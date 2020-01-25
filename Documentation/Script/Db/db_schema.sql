CREATE DATABASE ivms;


DROP TABLE IF EXISTS address;
DROP TABLE IF EXISTS contact_info;
DROP TABLE IF EXISTS billing_info;
DROP TABLE IF EXISTS receiver;
DROP TABLE IF EXISTS supplier;
DROP TABLE IF EXISTS invoice_item;
DROP TABLE IF EXISTS invoice_payment;


CREATE TABLE address (
  id SERIAL PRIMARY KEY,
  country VARCHAR(255) NOT NULL,
  city VARCHAR(255) NOT NULL,
  street VARCHAR(255) NOT NULL,
  state VARCHAR(255) NOT NULL,
  building_number INTEGER NOT NULL,
  flat_number INTEGER
);

CREATE TABLE contact_info (
    id SERIAL PRIMARY KEY,
    email VARCHAR(255) NOT NULL,
    phone VARCHAR(255),
    mobile VARCHAR(255),
    title VARCHAR(255),
    gender VARCHAR(255),
    name VARCHAR(255) NOT NULL,
    surname VARCHAR(255)
);

CREATE TABLE billing_info (
    id SERIAL PRIMARY KEY,
    company_name VARCHAR(255) NOT NULL,
    zip_code VARCHAR(20) NOT NULL,
    address_id BIGINT NOT NULL 
        REFERENCES contact_info(id)
          ON UPDATE CASCADE
          ON DELETE NO ACTION
);

CREATE TABLE receiver (
    id SERIAL PRIMARY KEY,
    billing_info_id BIGINT NOT NULL
        REFERENCES billing_info(id)
            ON UPDATE CASCADE
            ON DELETE NO ACTION,
    contact_info_id BIGINT NOT NULL
        REFERENCES contact_info(id)
            ON UPDATE CASCADE
            ON DELETE NO ACTION
);

CREATE TABLE supplier (
    id SERIAL PRIMARY KEY,
    billing_info_id BIGINT NOT NULL
        REFERENCES billing_info(id)
            ON UPDATE CASCADE
            ON DELETE NO ACTION,
    contact_info_id BIGINT NOT NULL
        REFERENCES contact_info(id)
            ON UPDATE CASCADE
            ON DELETE NO ACTION
);

CREATE TABLE invoice_item (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    unit_price NUMERIC NOT NULL,
    unit_type VARCHAR(30) NOT NULL,
    discount NUMERIC NOT NULL,
    quantity NUMERIC NOT NULL
);

CREATE TABLE invoice_payment (
    id BIGSERIAL PRIMARY KEY,
    type VARCHAR(120) NOT NULL,
    date DATE NOT NULL,
    time_zone VARCHAR(255),
    amount NUMERIC NOT NULL
);
