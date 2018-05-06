package program;

import java.util.ArrayList;
import java.util.List;
import java.util.Queue;
import java.util.concurrent.ConcurrentLinkedQueue;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.stream.IntStream;

public class ProduceAndConsume {

    // obiekt który służy do usypiania i wybudzania wątków. Jest przekazywany do wszystkich wątków
    Object LOCK = new Object();

    // inicjalizacja kolejek, które wspierają wielowątkowość
    public static ConcurrentLinkedQueue<Item> produceQueue = new ConcurrentLinkedQueue<>();
    public static ConcurrentLinkedQueue<Item> consumeQueue = new ConcurrentLinkedQueue<>();

    // liczniki, które mówia ile obiektów zostało stworzonych i skonsumowanych
    public static final AtomicInteger Produced = new AtomicInteger();
    public static final AtomicInteger Consumed = new AtomicInteger();

    public ProduceAndConsume(){

        // wstaw do kolejki 100 obiektów Item
        IntStream.range(0, 100)
                .forEach((i) ->
                        //items.add(new Item())
                        produceQueue.add(new Item())
                );
    }

    public void startProcess(){
        NewProducer[] producers = new NewProducer[4];

        IntStream.range(0, 4).forEach((i) -> {
            producers[i] = new NewProducer(LOCK);
        });

        NewConsumer[] consumers = new NewConsumer[3];

        // utworzenie 3 watkow konsumujacych
        IntStream.range(0, 3).forEach((i) -> {
            consumers[i] = new NewConsumer(LOCK);
        });

        // program bedzie czekal do czasu, az watki konsumujace skoncza swoje zadanie
        IntStream.range(0, 3).forEach((i) -> {
            try {
                consumers[i].getThread().join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        System.out.println("End of process. Produced: " + Produced.get() + " Consumed: " + Consumed.get());

    }

}
