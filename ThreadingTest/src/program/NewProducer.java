package program;

public class NewProducer implements Runnable {

    // obiekt który służy do usypiania i wybudzania wątków
    Object LOCK = new Object();

    private Thread thread;

    NewProducer(Object LOCK){
        this.LOCK = LOCK;
        thread = new Thread(this);
        thread.start();
    }

    public Thread getThread(){
        return thread;
    }

    @Override
    public void run() {
        while(!ProduceAndConsume.produceQueue.isEmpty()){
            Item takenItem = ProduceAndConsume.produceQueue.poll(); // pobierz item z kolejki

            takenItem.produceMe(); // wyprodukuj go

            ProduceAndConsume.consumeQueue.add(takenItem); // po wyprodukowaniu dodaj go do kolejki, w której będzie się konsumowało

            ProduceAndConsume.Produced.getAndIncrement(); // zwiększ licznik o jeden

            synchronized (LOCK){
                LOCK.notifyAll(); // powiadom, że można już skonsumować utworzony item
            }
        }

        System.out.println("Producer has been stopped - ID " + thread.getId());
    }
}
