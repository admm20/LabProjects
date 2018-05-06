package program;

public class NewConsumer implements Runnable {

    // obiekt który służy do usypiania i wybudzania wątków
    Object LOCK = new Object();

    private Thread thread;

    NewConsumer(Object LOCK) {
        this.LOCK = LOCK;
        thread = new Thread(this);
        thread.start();
    }

    public Thread getThread() {
        return thread;
    }

    @Override
    public void run() {
        while (ProduceAndConsume.Consumed.get() < 100) {
            // pobierz item z kolejki
            Item takenItem = ProduceAndConsume.consumeQueue.poll();

            if (takenItem != null) {
                takenItem.consumeMe(); // skonsumuj go
                ProduceAndConsume.Consumed.getAndIncrement(); // zwiększ licznik o jeden

                synchronized (LOCK) {
                    LOCK.notifyAll(); // powiadom wszystkie wątki gdy skonsumowano item
                }
            }

            // jezeli kolejka jest pusta i nie skonsumowano jeszcze 100 itemow
            if (ProduceAndConsume.consumeQueue.isEmpty() && ProduceAndConsume.Consumed.get() < 100) {
                synchronized (LOCK) {
                    // podobno metoda 'wait()' nie zawsze dziala, wiec trzeba ja umiescic w petli while
                    while(ProduceAndConsume.consumeQueue.isEmpty() && ProduceAndConsume.Consumed.get() < 100){
                        try {
                            System.out.println("CZEKAM: " + thread.getId());
                            LOCK.wait();
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }

                }
            }
        }
        System.out.println("Consumer has been stopped - ID " + thread.getId());
    }
}
