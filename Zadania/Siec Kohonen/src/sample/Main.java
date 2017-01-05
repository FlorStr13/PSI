package sample;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import topology.*;
import network.*;
import learningFactorFunctional.*;
import kohonen.*;
import metrics.*;

public class Main extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception{
        Parent root = FXMLLoader.load(getClass().getResource("sample.fxml"));
        primaryStage.setTitle("Hello World");
        primaryStage.setScene(new Scene(root, 300, 275));
        primaryStage.show();
    }


    public static void main(String[] args) {
        MatrixTopology topology = new MatrixTopology(4,4);
        double[] maxWeight = {200,100};
        DefaultNetwork network = new DefaultNetwork(2,maxWeight,topology);
        ConstantFunctionalFactor constantFactor = new ConstantFunctionalFactor(0.8);
        LearningData fileData = new LearningData("C:\\Users\\User\\Documents\\GitHub\\PSI\\Zadania\\Siec Kohonen\\src\\sample\\trainning_data.txt");
        WTALearningFunction learning = new WTALearningFunction(network,20,new EuclidesMetric(),fileData,constantFactor);
        learning.setShowComments(true);
        learning.learn();
        System.out.println(network);
    }
}
