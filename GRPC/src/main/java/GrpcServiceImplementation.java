import grpc.GrpcRequest;
import grpc.GrpcResponse;
import grpc.GrpcServiceGrpc;


public class GrpcServiceImplementation extends GrpcServiceGrpc.GrpcServiceImplBase {

    @Override
    public void getDrug(GrpcRequest request,
                        io.grpc.stub.StreamObserver<GrpcResponse> responseObserver) {

        GrpcResponse res = GrpcResponse.newBuilder().setResult("OK").build();

        responseObserver.onNext(res);
        responseObserver.onCompleted();
    }
}
