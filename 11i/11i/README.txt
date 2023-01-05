Alexander Husted

Vigtigste beslutninger:
get_data()
    her anvendes samme metode som i øvelse 5c.

to_metric(deathrow_data)
    Jeg anvender et for loop til at gå igennem alle rækkkerne.
    Jeg har tilføjet if statements til at filtrere
    de tomme strenge ud.

county_statistics(deathrow_data)
    Jeg anvender et for loop til at gå igennem alle rækkkerne.
    Første gang en county bliver opdaget bliver der oprettet en nøgle,
    og for hver gang den nøgle bliver fundet på en ny række øges værdien med 1.

native_statistics(deathrow_data)
    Jeg anvender et for loop til at gå igennem alle rækkkerne.
    Første gang en nativ county bliver opdaget bliver der oprettet en nøgle,
    og for hver gang den nøgle bliver fundet på en ny række øges værdien med 1.

last_words_search
    Jeg anvender et for loop til at gå igennem alle rækkkerne.
    Herfra bliver endnu et for loop anvendt til at gennemgå last statement af
    hver fange.
    Under loopet anvendes et if statement til at finde matchs.