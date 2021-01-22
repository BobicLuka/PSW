import io.grpc.ServerBuilder;

import java.io.IOException;

public class Server {
    public static void main(String[] args) throws IOException, InterruptedException {

        GrpcServiceImplementation impl = new GrpcServiceImplementation();

        io.grpc.Server server = ServerBuilder
                .forPort(8009)
                .addService(impl).build();

        server.start();
        server.awaitTermination();
    }
}
