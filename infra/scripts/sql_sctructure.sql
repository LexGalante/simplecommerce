CREATE TABLE public.states (
	id varchar(2) NOT NULL,
	"name" varchar(50) NOT NULL,
	CONSTRAINT pk_states PRIMARY KEY (id)
);

CREATE TABLE public.cities (
	id int NOT NULL,
	"name" varchar(250) NOT NULL,
	id_state varchar(2) NOT NULL,
	CONSTRAINT pk_cities PRIMARY KEY (id),
	CONSTRAINT fk_cities_states FOREIGN KEY (id_state) REFERENCES public.states(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE public.customers (
	id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
	email varchar(250) NOT NULL,
	name varchar(150) NULL,
	birth_date timestamp NULL,
	created_at timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	updated_at timestamp NULL,
	active boolean NOT NULL DEFAULT false,
	CONSTRAINT pk_clientes PRIMARY KEY (id),
	CONSTRAINT un_clientes_email UNIQUE (email)
);

CREATE TABLE public.customers_addresses (
	id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
	id_customer bigint NOT NULL,
	id_city int NOT NULL,
	street_name varchar(250) NOT NULL,
	street_number varchar(5) NULL,
	details varchar(250) NULL,
	district varchar(100) NOT NULL,
	postal_code varchar(8) NOT NULL,
	CONSTRAINT pk_addresses PRIMARY KEY (id),
	CONSTRAINT fk_customers_addresses_addresses FOREIGN KEY (id_city) REFERENCES public.cities(id) ON DELETE CASCADE ON UPDATE CASCADE
	CONSTRAINT fk_customers_addresses_customers FOREIGN KEY (id_customer) REFERENCES public.customers(id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE public.customers_phones (
	id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
	ddi smallint NOT NULL,
	ddd smallint NOT NULL,
	"number" smallint NOT NULL,
	id_customer bigint NOT NULL,
	CONSTRAINT pk_customers_phones PRIMARY KEY (id),
	CONSTRAINT ck_customers_phones_ddi CHECK (ddi = 55),
	CONSTRAINT ck_customers_phones_ddd CHECK (ddd IN(61, 62, 64, 65, 66, 67, 82, 71, 73, 74, 75, 77, 85, 88, 98, 99, 83, 81, 87, 86, 89, 84, 79, 68, 96, 92, 97, 91, 93, 94, 69, 95, 63, 27, 28, 31, 32, 33, 34, 35, 37, 38, 21, 22, 24, 11, 12, 13, 14, 15, 16, 17, 18, 19, 41, 42, 43, 44, 45, 46, 51, 53, 54, 55, 47, 48, 49)),
	CONSTRAINT fk_customers_phones FOREIGN KEY (id_customer) REFERENCES public.customers(id) ON DELETE CASCADE ON UPDATE CASCADE
);

