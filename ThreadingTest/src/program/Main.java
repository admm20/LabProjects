package program;

import java.util.ArrayList;
import java.util.List;
import java.util.Queue;
import java.util.Scanner;
import java.util.concurrent.*;
import java.util.stream.IntStream;

public class Main {


    public static void main(String[] args) throws Exception{
        System.out.println("Start");

        //
        //
        // część pierwsza - 4 wątki produkujące i 3 konsumujące
        // Utworzone zostaly 2 kolejki 'produce' i 'consume'. Watki produkujace pobieraja obiekty Item z pierwszej kolejki, produkuja je
        // i po wyprodukowaniu przenosza do drugiej kolejki. Wraz z przeniesieniem wywolywana jest metoda notifyAll(), ktora budzi watki
	// konsumujace. Po wyprodukowaniu i skonsumowaniu 100 obiektow Item proces konczy sie.
	//
        ProduceAndConsume process = new ProduceAndConsume();
        process.startProcess();

        System.out.println("Wpisz 'y' i wcisnij enter...");
        Scanner s = new Scanner(System.in);
        String key = s.next();



        //
        //
        // część druga: pula wątków
        //
        //
        ExecutorService es = Executors.newCachedThreadPool(); //Executors.newFixedThreadPool(100);

        Callable<Item> executeItem = () -> {
            Item item = new Item();
            item.produceMe();
            item.consumeMe();
            return item;
        };

        List<Callable<Item>> callableList = new ArrayList<>();
        IntStream.range(0, 100).forEach(i -> callableList.add(executeItem));

        List<Future<Item>> results = es.invokeAll(callableList);

        int numberOfResults = results.size();
        System.out.println("Wyprodukowanych i skonsumowanych obiektów Item: " + numberOfResults);

        es.shutdown();

        System.out.println("Wpisz 'y' i wcisnij enter...");
        key = s.next();



        //
        //
        // trzecia część: parallelStream
        //
        //
        List<Item> itemList = new ArrayList<>();

        // dodaj 100 itemów do listy
        IntStream.range(0, 100)
                .forEach(i ->
                        itemList.add(new Item())
                );

        itemList.parallelStream().forEach(item -> {
            item.produceMe();
            item.consumeMe();
        });

        System.out.println("End");
    }
}
