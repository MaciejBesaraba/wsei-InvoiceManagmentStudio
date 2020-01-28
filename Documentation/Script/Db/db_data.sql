INSERT INTO address (id, country, state, city, street, building_number, flat_number)
     VALUES (1, 'Polska', 'Małopolska', 'Kraków',   'Grodzka',    56,  6),
            (2, 'Polska', 'Mazowiekie', 'Warszawa', 'Wiejska',    17, 18),
            (3, 'Polska', 'Śląskie',    'Gliwice',  'Zwycięstwa',  7,  7);


INSERT INTO contact_info (id, email, phone, mobile, title, gender, name, surname)
     VALUES (1, 'amoraczynski@dadada.pl', '12258974', '567567567', 'Doradca do spraw klienta', 'Male',   'Andrzej', 'Moraczyński'),
            (2, 'dagmara-klos@gmail.com', '12258975', '765765765', 'CEO',                      'Female', 'Dagmara', 'Kłos'),
            (3, 'jan.zadworek@emikal.pl', '12258976', '123456789', 'Project Manager',          'Male',   'Jan',     'Zadworek');


INSERT INTO billing_info (id, company_name, zip_code, address_id)
     VALUES (1, 'Da-Da-Da Sp. z o.o.', '4177251692', 1),
            (2, 'Dagmara Kłos',        '9716565869', 2),
            (3, 'Emikal s.c.',         '7768503796', 3);


INSERT INTO supplier (id, billing_info_id, contact_info_id)
     VALUES (1, 1, 1);


INSERT INTO receiver (id, billing_info_id, contact_info_id)
     VALUES (2, 2, 2),
            (3, 3, 3);


INSERT INTO invoice_item (id, name, unit_price, unit_type, discount, quantity)
     VALUES -- Invoice 1
            (1, 'Łóżko dziecięce',      399.99, 'Quantity',   12.10,   1),
            (2, 'Szafka nocna',          99.99, 'Quantity',    0.00,   2),
            (3, 'Dowóz',                 24.34, 'TimePeriod',  0.00,   1),
            -- Invoice 2
            (4, 'Łóżko dwuosobowe',     599.99, 'Quantity',   12.60,   1),
            (5, 'Dowóz',                 12.11, 'TimePeriod',  1.10,   1),
            -- Invoice 3
            (6, 'Materac',               89.99, 'Quantity',    0.00, 269),
            -- Invoice 4
            (7, 'Kuchenka indukcyjna', 1419.00, 'Quantity',   12.00,   11),
            (8, 'Montaż',               120.00, 'TimePeriod',  0.00,   45),
            (9, 'Dowóz',                 56.78, 'TimePeriod', 56.78,    7);


INSERT INTO invoice_payment (id, type, date, time_zone, amount)
     VALUES -- Invoice 1
            (1, 'Cash',           '2019-12-12T12:12:12', '01:00:00',   387.99),
            (2, 'BankTransfer',   '2019-12-15T12:15:15', '01:00:00',   224.14),
            -- Invoice 2
            (3, 'CardVisa',       '2020-01-01T01:01:01', '01:00:00',   598.40),
            -- Invoice 3
            (4, 'CardMasterCard', '2020-01-12T08:00:01', '01:00:00', 24207.31)
            -- Invoice 4
            -- not payed yet
            ;


INSERT INTO invoice (id, issue_date, due_date, redemption_date, supplier_id, receiver_id)
     VALUES (1, '2019-12-12T12:00:00', '2020-01-12T12:00:00', '2019-12-15T12:15:15', 1, 2),
            (2, '2020-01-01T01:00:00', '2020-02-01T01:00:00', '2020-01-01T01:01:01', 1, 2),
            (3, '2020-01-12T08:00:00', '2020-02-12T12:00:00', '2020-01-12T08:00:01', 1, 3),
            (4, '2020-01-28T16:00:00', '2020-01-27T16:00:00',                  null, 1, 2);


INSERT INTO invoice_items (invoice_id, item_id)
     VALUES (1, 1),
            (1, 2),
            (1, 3),

            (2, 4),
            (2, 5),

            (3, 6),

            (4, 7),
            (4, 8),
            (4, 9);


INSERT INTO invoice_payments (invoice_id, item_id)
     VALUES (1, 1),
            (1, 2),

            (2, 3),

            (3, 4)
            -- Invoice 4
            -- no payments
            ;


