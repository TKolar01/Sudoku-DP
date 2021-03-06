:- use_module(library(clpfd)).

upute('Cilj igre je ispuniti sva polja brojevima od 1 do 9, s time da se svaki broj smije pojaviti tocno 9 puta. Problematika je u tome sto se jedan broj smije pojaviti samo jednom u svakom retku, svakom stupcu i svakom odjeljku od 3x3 polja. Na pocetku igre, otkriveni su odredeni brojevi, a rjesavac mora otkriti gdje se nalaze svi ostali brojevi i kako su rasporedeni. Sudoku moze imati vise rjesenja, ako je na pocetku otkriveno malo brojeva. Zato treba paziti da se greska ne nacini na pocetku rjesavanja. Jedini nacin rjesavanja sudokua je metoda eliminacije, a tu se koristi svojstvom da se jedan broj smije pojaviti samo jednom u svakom stupcu, retku i bloku. Rjesavanje postaje lakse ukuliko se otkrije vise brojeva. ').

sudoku(TezinaProblema,Broj, Rjesenje) :-
        problem(TezinaProblema,Broj,Zadatak),
         Matrica = [S11, S12, S13, S14, S15, S16, S17, S18, S19,
                  S21, S22, S23, S24, S25, S26, S27, S28, S29,
                  S31, S32, S33, S34, S35, S36, S37, S38, S39,
                  S41, S42, S43, S44, S45, S46, S47, S48, S49,
				  S51, S52, S53, S54, S55, S56, S57, S58, S59,
				  S61, S62, S63, S64, S65, S66, S67, S68, S69,
				  S71, S72, S73, S74, S75, S76, S77, S78, S79,
				  S81, S82, S83, S84, S85, S86, S87, S88, S89,
				  S91, S92, S93, S94, S95, S96, S97, S98, S99],
        flatten(Zadatak,Matrica),


        ins(Matrica, 1..9),

        Red1= [S11, S12, S13, S14, S15, S16, S17, S18, S19],
        Red2 = [S21, S22, S23, S24, S25, S26, S27, S28, S29],
        Red3 = [S31, S32, S33, S34, S35, S36, S37, S38, S39],

        Red4 = [S41, S42, S43, S44, S45, S46, S47, S48, S49],
		Red5 = [S51, S52, S53, S54, S55, S56, S57, S58, S59],
        Red6 = [S61, S62, S63, S64, S65, S66, S67, S68, S69],

		Red7 = [S71, S72, S73, S74, S75, S76, S77, S78, S79],
		Red8 = [S81, S82, S83, S84, S85, S86, S87, S88, S89],
		Red9 = [S91, S92, S93, S94, S95, S96, S97, S98, S99],



        all_distinct(Red1),
        all_distinct(Red2),
        all_distinct(Red3),
        all_distinct(Red4),
        all_distinct(Red5),
        all_distinct(Red6),
        all_distinct(Red7),
        all_distinct(Red8),
        all_distinct(Red9),


        Stupac1 = [S11, S21, S31, S41, S51, S61, S71, S81, S91],
        Stupac2 = [S12, S22, S32, S42, S52, S62, S72, S82, S92],
        Stupac3 = [S13, S23, S33, S43, S53, S63, S73, S83, S93],
        Stupac4 = [S14, S24, S34, S44, S54, S64, S74, S84, S94],
		Stupac5 = [S15, S25, S35, S45, S55, S65, S75, S85, S95],
		Stupac6 = [S16, S26, S36, S46, S56, S66, S76, S86, S96],
		Stupac7 = [S17, S27, S37, S47, S57, S67, S77, S87, S97],
		Stupac8 = [S18, S28, S38, S48, S58, S68, S78, S88, S98],
		Stupac9 = [S19, S29, S39, S49, S59, S69, S79, S89, S99],

        all_distinct(Stupac1),
        all_distinct(Stupac2),
        all_distinct(Stupac3),
        all_distinct(Stupac4),
        all_distinct(Stupac5),
        all_distinct(Stupac6),
        all_distinct(Stupac7),
        all_distinct(Stupac8),
        all_distinct(Stupac9),

        Kvadrat1 = [S11, S12, S13, S21, S22, S23, S31, S32, S33],
        Kvadrat2 = [S14, S15, S16, S24, S25, S26, S34, S35, S36],
        Kvadrat3 = [S17, S18, S19, S27, S28, S29, S37, S38, S39],

        Kvadrat4 = [S41, S42, S43, S51, S52, S53, S61, S62, S63],
        Kvadrat5 = [S44, S45, S46, S54, S55, S56, S64, S65, S66],
        Kvadrat6 = [S47, S48, S49, S57, S58, S59, S67, S68, S69],

        Kvadrat7 = [S71, S72, S73, S81, S82, S83, S91, S92, S93],
        Kvadrat8 = [S74, S75, S76, S84, S85, S86, S94, S95, S96],
        Kvadrat9 = [S77, S78, S79, S87, S88, S89, S97, S98, S99],

        Rjesenje = [[_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_],
        [_,_,_,_,_,_,_,_,_]],

        flatten(Rjesenje, Matrica),
        all_distinct(Kvadrat1),
        all_distinct(Kvadrat2),
        all_distinct(Kvadrat3),
        all_distinct(Kvadrat4),
        all_distinct(Kvadrat5),
        all_distinct(Kvadrat6),
        all_distinct(Kvadrat7),
        all_distinct(Kvadrat8),
        all_distinct(Kvadrat9),
        labeling([],Matrica).



problem(lagana,1, [[_,_,_,_,_,_,_,_,_],
            [_,_,_,_,_,3,_,8,5],
            [_,_,1,_,2,_,_,_,_],
            [_,_,_,5,_,7,_,_,_],
            [_,_,4,_,_,_,1,_,_],
            [_,9,_,_,_,_,_,_,_],
            [5,_,_,_,_,_,_,7,3],
            [_,_,2,_,1,_,_,_,_],
            [_,_,_,_,4,_,_,_,9]]).

problem(lagana,2, [[7,_,_,_,1,4,8,5,_],
            [6,4,_,_,_,_,_,_,2],
            [3,_,_,2,_,7,_,_,_],
            [_,7,_,_,3,_,_,2,6],
            [9,_,4,_,_,1,_,_,7],
            [_,_,_,_,_,_,_,_,_],
            [_,_,_,_,7,_,6,_,_],
            [1,9,_,3,_,_,5,_,_],
            [_,_,_,_,_,5,_,1,_]]).

problem(lagana,3, [[_,9,_,_,2,4,_,5,_],
            [_,_,_,_,_,_,1,6,_],
            [3,_,2,_,_,_,_,_,_],
            [_,4,5,1,_,_,_,2,_],
            [_,_,1,_,_,_,_,_,_],
            [6,7,_,_,9,8,_,_,_],
            [_,_,_,9,_,5,_,_,7],
            [8,1,_,_,_,_,_,9,_],
            [_,_,9,7,1,_,_,_,_]]).



problem(srednja,1,[[_,6,_,1,_,4,_,5,_],
         [_,_,8,3,_,5,6,_,_],
         [2,_,_,_,_,_,_,_,1],
         [8,_,_,4,_,7,_,_,6],
         [_,_,6,_,_,_,3,_,_],
         [7,_,_,9,_,1,_,_,4],
         [5,_,_,_,_,_,_,_,2],
         [_,_,7,2,_,6,9,_,_],
         [_,4,_,5,_,8,_,7,_]]).

problem(srednja,2,[[6,_,_,_,7,_,_,8,_],
         [_,5,_,_,_,_,_,1,6],
         [_,_,_,_,4,_,5,_,_],
         [_,_,_,_,6,_,_,4,_],
         [1,9,3,_,_,2,_,_,_],
         [_,_,_,_,_,_,3,9,_],
         [3,_,_,_,_,_,_,_,7],
         [5,_,_,6,2,_,9,_,_],
         [_,8,_,_,_,9,6,_,_]]).

problem(srednja,3,[[_,6,_,1,_,4,_,5,_],
         [_,_,8,3,_,5,6,_,_],
         [2,_,_,_,_,_,_,_,1],
         [8,_,_,4,_,7,_,_,6],
         [_,_,6,_,_,_,3,_,_],
         [7,_,_,9,_,1,_,_,4],
         [5,_,_,_,_,_,_,_,2],
         [_,_,7,2,_,6,9,_,_],
         [_,4,_,5,_,8,_,7,_]]).

problem(teska,1,[[_,_,_,1,5,_,_,7,_],
        [1,_,6,_,_,_,8,2,_],
        [3,_,_,8,6,_,_,4,_],
        [9,_,_,4,_,_,5,6,7],
        [_,_,4,7,_,8,3,_,_],
        [7,3,2,_,_,6,_,_,4],
        [_,4,_,_,8,1,_,_,9],
        [_,1,7,_,_,_,2,_,8],
        [_,5,_,_,3,7,_,_,_]]).

problem(teska,2,[[4,_,_,_,7,8,9,_,_],
        [3,_,_,_,_,2,_,_,_],
        [_,2,7,_,_,_,5,6,_],
        [7,_,_,_,_,_,_,_,_],
        [_,_,_,_,9,7,2,8,_],
        [_,_,4,_,_,_,3,_,1],
        [_,_,_,_,_,_,_,_,_],
        [9,_,_,_,8,_,4,_,_],
        [2,6,_,5,_,_,_,_,_]]).

problem(teska,3,[[_,_,5,_,7,2,1,_,_],
        [_,7,_,_,_,3,_,8,_],
        [_,_,_,_,_,_,_,9,7],
        [2,8,_,6,4,_,5,1,3],
        [_,3,1,2,_,_,4,_,_],
        [4,_,6,_,_,_,_,_,8],
        [_,4,_,_,_,1,_,5,_],
        [_,_,_,_,5,_,_,_,_],
        [5,_,_,_,_,_,9,7,6]]).
